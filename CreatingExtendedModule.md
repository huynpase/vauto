## How to extend a module? ##
_Note: Vibz Automation framework can be extended in four different directions. [Read here](http://code.google.com/p/vauto/wiki/ExtensibleFrameworkConcept)_

This article will explain the process to extend each of these modules.

### Extending Instruction module ###
[Download Demo Source](http://vauto.googlecode.com/files/Ext_Instruction.zip)

#### Types of Instructions ####
Framework identifies three types of instructions based on their behavior.
  * **Action**: Actions are instructions which interferes with Application under test (AUT) to do some task. It returns a bool stating whether the instruction failed or passed.
  * **Assert**: Assert instructions does not perform any operation on the AUT. Rather it does some checks and returns a boolean stating whether the check condition passed or failed.
  * **Fetch**: Fetch instruction retrieves some value from the AUT and assigns it to a variable given.
> Based on the type of instruction, a module developer has to follow some specific steps given below.

#### About Demo ####
The example has a extension project 'demo\_ext\_instruction' that demonstrates extension to each type of instruction. Along with extended module there is a test project 'test\_demo\_ext\_inst' which shows the usage of the new module.

#### Steps ####
  * Create a new class library project.
  * Add reference to following Vibz.Contract.dll. [Download here](http://vauto.googlecode.com/files/Vibz.Contract.dll.zip)
  * One can define as many instruction in an instruction library project. However, as a best practice, use related instructions basing on target of usage (say instruction dealing with database activity should be bundled in one library package).
  * For each instruction, define a seperate class.
  * Add reference to following namespace in your class.
    * System.Xml.Serialization;
    * Vibz.Contract;
    * Vibz.Contract.Attribute;
  * (Optional) Add TypeInfo class attribute before the class begin (sample shown below).
```
namespace demo_ext_instruction.Calendar
{
    [TypeInfo(Author="Vibzworld", Details = "Changes the system date.",
        Version = "2.0")]
    public class IsDayToday : InstructionBase, IAssert
    {
        bool _assertValue = false;
```
> > The Studio uses informations stored in TypeInfo to help script writers during scripting. These informations are displayed as context help.
  * All class must inherit '<font color='green'>InstructionBase</font>' from namespace Vibz.Contract.
  * Steps till now is common to all types of instruction. Now, it's the to decide upon the [type of instruction](http://code.google.com/p/vauto/wiki/CreatingExtendedModule#Types_of_Instructions) and follow some specific step.
    * **Action instruction**: If the instruction is going to perform some action, the class should implement <font color='green'>IAction</font> interface. To implement IAction you need to provide defination for <font color='green'>Execute</font> function as shown below.
```
public void Execute(Vibz.Contract.Data.DataHandler vList)
{
  // Your code block of action
}
```
    * **Assert instruction**: If the instruction is going to do some check, the class should implement <font color='green'>IAssert</font> interface. To implement IAssert you need to provide defination for <font color='green'>Assert</font> function as shown below.
```
public bool Assert(Vibz.Contract.Data.DataHandler vList)
{
  // Your code block of assertion
}
```
    * **Fetch instruction**: If the instruction is going to fetch some value, the class should implement <font color='green'>IFetch</font> interface. To implement IFetch you need to provide defination for <font color='green'>Fetch</font> function as shown below.
```
public Vibz.Contract.Data.IData Fetch(Vibz.Contract.Data.DataHandler vList)
{
  // Your code block for fetching
}
```

  * Your instruction may need one or more input parameters. For example the demonstrated sample action instruction <font color='green'>ChangeDate</font> accepts three arguments i.e. <font color='green'>date, month, year</font>. Similarly, sample fetch instruction <font color='green'>GetSystemDate</font> accepts one argument i.e. <font color='green'>assignto</font> These arguments can be defined as a public field or a get-set property as shown below.
```
[XmlAttribute("date")][AttributeInfo("Date to which the system date should be changed.")]
public string Date;

[XmlAttribute("assignto")][AttributeInfo("Variable where the instruction output will be stored.")]
public string Output
{
    get { return _output; }
    set { _output = value; }
}
```
> > Every field or the property must have XmlAttribute with the desired argument name associated to it. AttributeInfo is optional, to define information regarding the argument. The information will be used by the studio to help script writers with context sensitive help.
  * (Optional)You may want to see the instructions success-failure or fetched value or assertion result in your final report. To achieve this you need to override InfoEnd property as shown below.
```
public override Vibz.Contract.Log.LogElement InfoEnd
{
    get
    {
       return new Vibz.Contract.Log.LogElement("<-Your message goes here->");
    }
}
```
  * Last step is to build the instruction library and obtain the assembly file (dll).


> Following above steps one can create their own instruction library. Once the module is created next step is to [register the new library with the framework](RegisterModule.md).
### Extending Macro module ###
[Download Demo Source](http://vauto.googlecode.com/files/Ext_Macro.zip)

#### Types of Macros ####
Framework identifies two types of macro based on their behavior.
  * Macro Function:
  * Macro Variable:

#### About Demo ####
The example has a extension project 'demo\_ext\_macro' that demonstrates extension to each type of macro. Along with extended module there is a test project 'test\_demo\_ext\_macro' which shows the usage of the new module.

#### Steps ####
  * Create a new class library project.
  * Add reference to following Vibz.Contract.dll. [Download here](http://vauto.googlecode.com/files/Vibz.Contract.dll.zip)
  * to be continued

### Extending External Data module ###

### Extending Reports module ###