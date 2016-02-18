Automation Studio handles most of the complexity of project developmental process. With mere click it creates basic project structure with required files. Adding new files is a simple click process. A script writer need not worry about knowing bunch of instructions and their syntax. Any module on getting registered to the framework will have its instructions available in instruction dictionary. During scripting the studio provides the context sensitive help.<br />
> To further improve the user experience the studio has Instruction Dictionary tray from where user can directly drag and drop an instruction over the script. Following section explains the usage of Vibz automation Studio.
## Creating a new project ##
  * Open Automation Studio from Start -> Programs -> Vibzworl -> Automate.
  * Click on **File** Tab on top. Now click on **New Project** sub menu. Alternatively you can do this by pressing **CTRL + N** keys. This will open up a multi form wizard. In wizard screen fill the required details.
    * **Project Location** screen:
      * **Project Name**: Type project name in the first text box.
> > > _Note: The name can be any valid file name. This will be used to create the directory to store all the project files._
      * **Select Folder**: Select the root directory location where you would like to place the project folder.
      * Click **Next** button.
    * **Project Settings** screen:
      * **Build Path**: Select your desired build location.
> > > _Note: Build Path is the directory location where the compiled script files (VACS file) will be placed after compilation.. Build path is relative to the Project path. Default is **bin/Debug**. Optionally you can choose to change this path._
      * Click **Next** button.
    * **Report Location** screen:
      * **Select Folder**: Select your desired report path.
> > > _Note: Report path is the directory location where the final report/s will be generated._
      * **Overwrite past report**: If you select to overwrite past report, the selected folder will be updated with the latest report.i.e. Past reports will be lost. To preserve past reports uncheck this control. New report will be created using timestamp every time a test is executed.
      * Click **Finish** button.
## Creating Project files ##
  * **Creating New Folder**:
    * In solution explorer, right click on a folder where you like to create the new folder. From the context menu options click on the **Add New Folder** option. This will open up a new Folder wizard.
    * Type the name of the folder in the text box.
  * **Creating New Case File**:
    * In solution explorer, right click on a folder where you like to create the new case file. From the context menu options click on the **Add new case file** option. This will open up a **New Case file** wizard.
    * Type the name of the case file in the text box.
## Writing case function ##
  * When a case file is created using a wizard, a basic format is auto generated as shown below.
```
<section xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <include ref="Vibz.IO"/>
  ...
  <function name="tc1">
    <include id="mycase.id"></include>
    ...
    <data>
       ...
    </data>
    <body>
       ...
    </body>
  </function>
</section>
```

> > A case file contains the set of functions which shares a common application feature. It is an XML based script with **section** as its root node.
> > A section contains one or more **function** and set of module reference (defined with **include** node) being used by contained functions. Using an instruction without its reference will result into exception.<br />
> > Know more:<br />
    * [Structure of a function](FunctionStructure.md)
    * [Examples](Examples.md)
> > Automation studio helps scripters to write complex logic with simple instructions in no time. It displays the Instruction dictionary from where it becomes easy to drag-drop an instruction on to the case file.
> > Context help is yet another mechanism where user gets the complete guidance at the time of scripting.<br />
> > _Note: The prime goal of the automation studio is to provide an environment where automation engineer needs to devote full concentration on the application's functional aspect rather that knowing the instructions and their usage._
## Adding cases in a suite ##
  * To create a suite file one can directly drag drop a function onto a suite file.
  * There can be multiple suite files in a project.
  * When a suite file is compiled it creates a vacs with the same file name as that of the suite.<br />

> _Note: A suite file contains the logical flow of different functional unit(function)._
## Building a suite ##
  * To build suite, double click on the suite file name in the soluion explorer.
  * From in the **Task** sub menu click on the Compile option. <br />
> _Note: One can directly build and run the suite file from Task -> Run option._
## Project configuration ##
> -- Todo