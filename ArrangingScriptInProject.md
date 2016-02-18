## Arranging Script In a Project ##

> Using Vibz automation framework, the development phase during automation majorily deals in scripting down the functional aspect of the application under test (AUT). Once the project is created (Ref: [Starting a New Project](http://code.google.com/p/vauto/wiki/StartingNewProject)), you will be concerned only in modularizing the test script, by adding script files in your defined folder structure.
_Note: The script can be maintained in folder structure specific to application feature._

> Consider, I got to automate a real estate web site, that has a user component, Sale component and one e-commerse component. The user component is sub-divided into admin, manager, member and guest components. sale component has LandForSale and HouseForsale sub-components. To start with, I will modularize the test components and create the appropriate folder structure. For above scenario, The folder structure will look like:
  * Script --Root folder
    * User
      * Admin
      * Manager
      * Member
      * Guest
    * Sale
      * LandForSale
      * HouseForSale
    * ECom

_Note: After the folders have been created, the members in the team can now own one component and start scripting process._<br />
> Under each folder I will add the test script files. Ideally for each feature one should have one case file and one identifier file. All the functions, specific to the current feature should stay in the same case file. Details on adding a test component can be found [here](http://code.google.com/p/vauto/wiki/ComponentsOfTestscript).
_Note: You still can maintain multiple case file with in a feature folder._