## Components of a Test script ##
Before looking into Components of a test script you may want to look into
  * [Components of a Test Project](http://code.google.com/p/vauto/wiki/ComponentsOfTestProject)
  * [Arranging script in a project](http://code.google.com/p/vauto/wiki/ArrangingScriptInProject)

Now lets see, what are the components of a Test script.
  * <b>Test case file:</b> A test case file holds the functional aspects of the application logic.
    * The framework classifies the testcase file with extension <b>.tc</b>.
    * All the functions specific to one feature can be dumped into one case file. In other words, a case file is just a collection of various functionality of a feature and has no sequential significance.
    * A testcase can call another testcase from within.
    * While making a call to a test case function, the the caller is bound to pass the arguments as expected by the called test case function.
    * The functional flow can be controlled at each instruction level.
  * <b>Identifier file:</b> An identifier file holds the locators or the ids that bounds the instruction to the controls of the application.
    * All the controls of a complete feature can be placed in a single file.
    * The testcase file references the identifier file using the locator key.
  * <b>Test suite file:</b> A test suite file is a logical and sequential modeling of test cases.
    * A suite can call a test case or another test suite.
    * The functional flow can be controlled at each call level.
    * While making a call to a test case function, the the caller is bound to pass the arguments as expected by the called test case function.

_Note: A test case is the building block of a scenario. Framework doesn't support to build and execute a test case individually. Test suite is the actual executable unit and can be executed individually. To test a individual test case function a function should be wrapped inside a test suite file._

After you have seen the components of a test script you may would like to know:
  * [Building and Executing a test suite](http://code.google.com/p/vauto/wiki/BuildingTestSuite)