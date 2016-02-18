## Registering an module ##
> There are two modes of registering a module to a framework.
  * **Manual**: Adding an entry into vibz.reg file.
    * While manually registering your module you need to place your assembly at your installed location(i.e folder where you have installed Vibz automation). Example: for me its **C:\Program Files\Vibzworld\Automation Studio**.
> > > - The installed folder will have plugin folder. Plugin folder has sub folders specific to each type of modules. Consider the new module is an instruction library say 'inst\_lib.dll'. To register this dll create a new folder say 'my\_lib' inside {Install\_loc}/plugin/instruction folder. <br />
> > > - Then place your assembly and all its references under this folder.
    * Now you need to update vibz.reg file. vibz.reg file will be located at your installed location.
    * Open the file in any text editor
    * The file basically has four sections: data, instruction, macro and report. Based on the type of module you need to add the reference to your module assembly under specific section.
> > > Example: For above consideration you will add the entry under instruction section as shown below:
```
<configuration versionsupport="...">
  <data>
    ...
  </data>
  <instruction>
    ...
    <include name="some_name" path="plugin\instruction\my_lib\inst_lib.dll" />
  </instruction>
  <macro>
    ...
  </macro>
  <report>
   ...  
  </report>
</configuration>
```
<br />

> > The name is the identity for the library. This name is to be displayed on Studio and Extension manager.
  * **Through a zipped file**: In case you want to share your module with other user you can create a zip file. The installed Studio has a the Extension manager through which a user can easily register your module. This furthers supresses the complexity when your module itself is a big projects with multiple referenced files.

> To create a zip file you need to follow these steps.
    * Bundle all the module files in a folder.
    * Create a {name}.plg (any name) file in the same folder.
> > > [Example](http://vauto.googlecode.com/files/web.plg) - To be discused.
    * Zip the folder.
<p />

> > To verify whether your module is installed correctly you may check either of following.
    * Open Extension Manager. Under module specific tab you will be seeing your registered module.
    * Open Automation Studio. In Instruction dictionary you will see additional section with your extended functions in it.