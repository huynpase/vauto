[Download Source](http://vauto.googlecode.com/files/HelloWorld.zip) - [Download VACS](http://vauto.googlecode.com/files/HelloWorldVacs.zip)

### Pre-requisite ###
  * Vibz Automation Framework. [Download here](http://code.google.com/p/vauto/downloads/list?can=3&q=&colspec=Filename+Summary+Uploaded+Size+DownloadCount)

### Pre-knowledge ###
  * [Case file format](http://code.google.com/p/vauto/wiki/UsingVibzAutomationStudio#Writing_case_function)

### Description ###
The source files can be viewed through Vibz Automation Studio or in any editor. The source contains project files, a script folder and a suite folder. Script folder is where you can find the case file and identifier files. Suite folder contains the test suite file. There is a bin/Debug in the source folder which has compiled script (VACS) file.<br />
The Vacs (Vibz automation compiled script), is portable, self contained executable file that can be executed on any remote machine where Vibz Automation framework (VAF) is installed.<br />
Lets see the code in detail;<br />
  * <b>Case file</b>
```
<section xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <include ref="Vibz.IO"/>
  <function name="Say Hello">
    <include id="case1.id"></include>
    <data>
	<var name="message"></var>
    </data>
    <body>
	<textalert message="@message" display="fadecrawlin" direction="toptobottom" position="center" exit="autoclose" duration="10000"/>
    </body>
  </function>
</section>
```
    * The case file has one section node that contains one or more function nodes.
    * The section includes the module reference for 'Vibz.IO' since we are going to use an instruction 'textalert' which is provided by it. Similarly you need to include module reference for an instruction before calling it within the case file.
    * Above case file has a function named 'Say Hello'.
    * The function 'Say Hello' includes reference to the identifier file 'case1.id'. A function can have any number of identifier file references.
    * The data section defines the arguments to the function. The callee of the function will pass value to the arguments of the function.
    * The body section contains the logical flow of the test case.
<br />
  * <b>Identifier file</b>
```
<controls xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

</controls>
```
    * There is no identifier for the current test case, hence no control node is needed.
<br />
  * <b>Suite file</b>
```
<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="suite1" ref="Suite/suite1">
  <function name="Say Hello" ref="Script/case1/Say Hello">
    <data>
      <var name="message" source="Internal" type="Scalar">Hello World</var>
    </data>
  </function>
</suite>
```
    * The suite file calls the above function 'Say Hello' and passes on the value to the message argument.

### Output ###
Above example alerts the user with message passed through the suite file.
<br /><br />
If you are thinking what is so called automation involved here!!! Well, the example above just demonstrated the basics of scripting through Automation framework. To see a real time automation example lets see the second example '[Image collection.](http://code.google.com/p/vauto/wiki/ExampleImageCollection)'.

### You may need to know ###
  * [What happens when suite file is compiled.](http://code.google.com/p/vauto/wiki/BuildingTestSuite)
  * [Scheduling Automation Script](SchedulingAutomationScript.md)
  * [Other Examples](http://code.google.com/p/vauto/wiki/Examples)