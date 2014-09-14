testable-sitecore
=================

Highly testable code in Sitecore with MVC, Ninject, Synthesis, Moq, and NUnit

### Prerequisites

1. Sitecore 7.2
2. Visual Studio 2013

### Installation

1. Install and publish the Sitecore package MvcTestingDemoItems-1.00.zip to a clean throw-away Sitecore installation. 
2. Configure the MvcTestingDemo.Website project to deploy to your website
3. Modify App_Config/Include/Data.config to point to your /Data directory in Sitecore
4. Build the solution and deploy the Website project
5. (optional) If you will be modifying items and regenerating synthesis objects you will need to set paths appropriate to your installation in App_Config/Include/Synthesis.config
