using Moq;
using MvcTestingDemo.Business;
using MvcTestingDemo.Business.Adapters;
using MvcTestingDemo.Models;
using NUnit.Framework;
using Synthesis.FieldTypes.Adapters;
using Synthesis.Testing;
using System.Collections.Generic;
using System.Linq;

namespace MvcTestingDemo.UnitTests
{
    [TestFixture]
    public class MenuLogicTests
    {
        private MenuLogic _testSubject;
        private Mock<ISitecoreContext> _context;
        private Mock<IDatabaseAdapter> _database;

        [SetUp]
        public void SetUp()
        {
            _context = new Mock<ISitecoreContext>();
            _database = new Mock<IDatabaseAdapter>();
            _context.Setup(c => c.Database).Returns(_database.Object);

            _testSubject = new MenuLogic(_context.Object);
        }

        [Test]
        public void GetItems_HomeMissing_ReturnsEmptyCollection()
        {
            // Arrange
            INavigableItem home = null;
            _database.Setup(db => db.GetItem(It.IsAny<string>())).Returns(home);

            // Act
            var result = _testSubject.GetMenuItems();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetItems_OneChild_ReturnsOne()
        {
            // Arrange
            var home = new Mock<INavigableItem>();
            var axesAdapter = new Mock<IAxesAdapter>();
            var item1 = new Mock<INavigableItem>();
            item1.Setup(i => i.IncludedInNavigation).Returns(new TestBooleanField(true));
            item1.Setup(i => i.Axes).Returns(new Mock<IAxesAdapter>().Object);
            var children = new List<INavigableItem>()
            {
                item1.Object,
            };

            home.SetupGet(h => h.Axes).Returns(axesAdapter.Object);
            axesAdapter.Setup(a => a.GetChildren()).Returns(children);

            _database.Setup(db => db.GetItem("/sitecore/Content/Home")).Returns(home.Object);

            // Act
            var result = _testSubject.GetMenuItems();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetItems_OneExcludedOneNot_ReturnsOne()
        {
            // Arrange
            var home = new Mock<INavigableItem>();
            var axesAdapter = new Mock<IAxesAdapter>();

            var item1 = new Mock<INavigableItem>();
            item1.Setup(i => i.IncludedInNavigation).Returns(new TestBooleanField(true));
            item1.Setup(i => i.Axes).Returns(new Mock<IAxesAdapter>().Object);

            var item2 = new Mock<INavigableItem>();
            item2.Setup(i => i.IncludedInNavigation).Returns(new TestBooleanField(false));
            item2.Setup(i => i.Axes).Returns(new Mock<IAxesAdapter>().Object);

            var children = new List<INavigableItem>()
            {
                item1.Object,
                item2.Object
            };

            home.SetupGet(h => h.Axes).Returns(axesAdapter.Object);
            axesAdapter.Setup(a => a.GetChildren()).Returns(children);

            _database.Setup(db => db.GetItem("/sitecore/Content/Home")).Returns(home.Object);

            // Act
            var result = _testSubject.GetMenuItems();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }
    }
}
