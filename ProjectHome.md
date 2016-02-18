<b>Vibzworld</b> welcomes you to the world of Automation. <br />
Probably you are here because you have realized the importance of an unified framework for automation. In case you still have any doubts to some corner of your mind, I would suggest you to read the article '[Need for an Automation Framework](http://code.google.com/p/vauto/wiki/NeedForAFramework)'. <br />
<p><i>Note: Vibz Automation Framework is not a tool to perform some specific task, but is an infrastructure that provides the solution where different tools can plug itself and do their job in an unified manner. Hence providing a common platform to the automation engineer doing their job.</i></p>
Hope you are convinced with the need of a framework. Now you must be thinking what should be an ideal framework. So before looking into the features offered by Vibz Automation framework its worth going through [Automation strategy and the criteria for an ideal framework](http://code.google.com/p/vauto/wiki/IdealFramework)
| &lt;wiki:gadget url="http://www.ohloh.net/p/487879/widgets/project\_basic\_stats.xml" height="220" border="1"/&gt; | &lt;wiki:gadget url="http://www.ohloh.net/p/487879/widgets/project\_cocomo.xml" height="240" border="0"/&gt; |
|:-------------------------------------------------------------------------------------------------------------------|:-------------------------------------------------------------------------------------------------------------|
&lt;wiki:gadget url="https://vauto.googlecode.com/svn/trunk/WebSite/ads1.htm" height="130" width="740" border="0" /&gt;
## Key features of Vibz Automation framework. ##
<p><b><a href='http://code.google.com/p/vauto/wiki/ExtensibleFrameworkConcept'>Extensible framework</a></b>: Vibz Automation Framework is designed keeping in view the easy of extending the scope of automation to meet any requirement which can be automated. Whether it is a web automation or a windows automation, anything can be brought under the unified framework either by using built-in modules or including extended module to the framework. The scope can be extended in four different directions.<br>
<img src='http://vauto.googlecode.com/files/architecture2.jpg' /> <br />
<a href='http://code.google.com/p/vauto/wiki/ExtensibleFrameworkConcept'>Read More</a>
<p />
<p><b><a href='http://code.google.com/p/vauto/wiki/DataDrivenarchitecture'>Data driven architecture</a></b>: The framework architecture is designed such that the test driving instructions can be scripted into a flat Xml files. This level of abstractions provides functional QA's to focus more on test functionality rather looking into the complexities of under-lying tool. This further provides better scalability on a whole.<br />
<ul><li><b><a href='http://code.google.com/p/vauto/wiki/DataDrivenarchitecture'>Modular approach for scripting</a></b>: The test scripts can be maintained into smallest functional unit and there after can be invoked from any other test case that defines similar functionality within it. With this framework facilitates re-usability of code and easy of maintenance.<br />
</li></ul><blockquote>Any other extended logic's, like whether the test should fail at a point or should continue which is generally missing in a tool can be handled at modular level with in the framework. <br />
<a href='http://code.google.com/p/vauto/wiki/DataDrivenarchitecture'>Read more</a>
</blockquote><ul><li><b><a href='http://code.google.com/p/vauto/wiki/ComponentsOfTestscript'>Logic separated from Data</a></b>: To further improve the scalability and reduce the maintenance the scripts should be segregated three sections.<br>
<ol><li><b>Testcase section</b>
</li><li><b>Testdata section</b>
</li><li><b>Identifier section</b>
<p />
</li></ol></li></ul><blockquote><p><i>Note: Although the framework does not stop you from writing your script into a single file, but as a good practice we suggest our users to segregate them into different files which has least maintenance cost involved.</i><p />
<a href='http://code.google.com/p/vauto/wiki/ComponentsOfTestscript'>Read more</a>
</blockquote><ul><li><b><a href='http://code.google.com/p/vauto/wiki/LoopSupport'>Easy flow controlled using loops</a>:</b> Keeping in mind the various complexity of the automation the framework, does support the loops. Like most of the language the framework provides three types of Loop logic.<br>
<ol><li><b>For Loop</b>
</li><li><b>While Loop</b>
</li><li><b>Do-While Loop</b>
</li></ol></li></ul><blockquote><a href='http://code.google.com/p/vauto/wiki/LoopSupport'>Read more</a>
<p><b><a href='UsingVibzAutomationStudio.md'>Quick Automation using Vibz Automation Studio</a></b>: Team working on unified framework can have their 100 percent concentration on writing the functional aspect of the application. Vibz automation comes with a Automation Studio which provides single point of writing, building, configuring and testing automation script. In a distributed architectural system team can work on a single automation project yet on separate feature of it. They can very well maintain the source repository the way the application developers do.<br />
<a href='UsingVibzAutomationStudio.md'>Read more</a>
<p><b>Quick setup on Execution Environment</b>: To execute the automation script, the execution environment just need to have installed framework and the build script (executable file: VACS).<br>
Vibz Automation Framework offers the necessary run-time components<br>
to execute an automation script which was developed using Vibz Automation Studio.<br>
Build scripts is a single flat file generated after collating data from various test files. This build file can easily be ported or executed on any remote system provided the the framework is installed on it. <br />
<a href='UsingVibzAutomationStudio.md'>Read more</a>
<p><b><a href='SchedulingAutomationScript.md'>Scheduling of Build script</a></b>: Although the process is automated, there is a need to initiate the execution. The framework has gone a step ahead to provide a facility to schedule your script execution at some regular interval or on some criteria fulfillment. This is useful in case of running a bot to crawl a site or starting a testing process when a new build arrives. This is yet another open end where the framework can be extended to provide your own custom scheduling. One can have as many scheduled event running in parallel.<br />
<a href='SchedulingAutomationScript.md'>Read more</a>
<b>Support for Globalization</b>: With the extensible macro feature, globalization can easily be achieved by writing a language converter macro function (say translate(LANG_CODE)) and use it instead of hard coded data. <p />
<b>Easy of scripting</b>: With Automation Studio in place a script writer need not worry about knowing bunch of instructions and their syntax. Any module on getting registered to the framework will have its instructions available in instruction dictionary. During scripting the studio provides the context sensitive help.<br>
<a href='http://vauto.googlecode.com/files/contexthelp.JPG'>http://vauto.googlecode.com/files/contexthelp.JPG</a><p />
To further improve the user experience the studio has Instruction Dictionary tray from where user can directly drag and drop an instruction over the script.<br>
<h2>Live Examples</h2>
Now let us look something in action. Below are some samples that demonstrate the script in action and ease of writing automation scripts. <br />
</blockquote><ul><li><a href='ExampleHelloWorld.md'>Hello World</a><br />
</li><li><a href='ExampleImageCollection.md'>Image Collection</a><br />
</li><li><a href='ExampleStockData.md'>Stock Data Processing</a><br />
</li><li><a href='Examples.md'>more</a>
<h2>Quick Links</h2>
</li><li><a href='NeedForAFramework.md'>Need for an Automation Framework</a><br />
</li><li><a href='IdealFramework.md'>Automation strategy and the criteria for an ideal framework</a><br />
</li><li><a href='ExtensibleFrameworkConcept.md'>Concept of an Extensible framework</a><br />
</li><li><a href='DataDrivenarchitecture.md'>Data driven architecture</a><br />
</li><li><a href='SchedulingAutomationScript.md'>Scheduling Automation Script</a>
</li><li><a href='CreatingExtendedModule.md'>Know how to write your extended module.</a><br />
</li><li><a href='GetSourceCode.md'>Get Source Code</a><br /><br />
I invite developers to make a collaborative effort to demolish the boundaries of Automation. Interested developers can drop in their <br /><a href='http://groups.google.com/group/vauto-discuss/browse_thread/thread/eba5827c755879d0'>email id here</a> .<p />
Please drop your suggestions and feed-backs here.<br>
<wiki:gadget url="https://vauto.googlecode.com/svn/trunk/WebSite/gadget.htm" height="230" width="700" border="0" /><br>
<a href='http://www.softpedia.com/progClean/Vibz-Automation-Framework-Clean-175773.html'><img src='http://www.softpedia.com/base_img/softpedia_clean_award_f.gif' /></a>
<a href='http://www.softsea.com/'><img src='http://www.softsea.com/images/pro-logo-clean.gif' border='0' /></a>
<a href='http://www.soft82.com/download/windows/vibzworld-automation-studio/'><img src='http://www.soft82.com/images/produse/clean_awards/soft82_clean_award_62587.png' alt='Soft82 100% Clean Award For Vibzworld Automation Studio' border='0' width='167' height='129' /></a>