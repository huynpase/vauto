[Download Source](http://vauto.googlecode.com/files/ImageCollection.zip) - [Download VACS](http://vauto.googlecode.com/files/ImageCollectionVacs.zip)

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
  <include ref="Vibz.IO"/>
  <include ref="Vibz.Web"/>
  <function name="Extract All Image From URL">
    <include id="case1.id"></include>
    <data>
      <var name="url"/>
    </data>
    <body>
      <openurl url="@url" maxwait="120000"/>
      <downloadimages folderpath="images"/>
    </body>
  </function>
```
    * The function 'Extract All Image From URL' accepts the url as an argument.
    * OpenURL is the web function defined in Vibz.Web (included in the suite) module. It opens up the url into a browser.
    * downloadimages downloads all the images in the current page to the given folder location.
<br />

  * <b>Identifier file</b>
    * There is no identifier for the current test case, hence no control node is needed.
<br />

  * <b>Suite file - 1</b>
```
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="suite1" ref="Suite/suite1">
  <function name="Extract All Image From URL" ref="Script/case1/Extract All Image From URL">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://sify.com/finance/search-car-imagegallery.html]]></Value>
      </var>
    </data>
  </function>
  <function name="Extract All Image" ref="Script/case1/Extract All Image">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://sify.com/finance/search-bike-imagegallery.html]]></Value>
      </var>
    </data>
  </function>
</suite>
```
    * The suite calls the function 'Extract All Image From URL' multiple times with different urls. (i.e. Same function is reused.)
    * In order to process 10 urls either we need to call the same function 10 times with different url or can loop through list of urls as explained in next section.
<br />

  * <b>Case file - Added function</b>
```
  <include ref="Vibz.IO"/>
  <include ref="Vibz.Web"/>
  <function name="Extract All Image From URL">
    ... See above ...
  </function>
  <function name="Extract All Image From all URLs">
    <include id="case1.id"></include>
    <data>
      <var name="urls" type="array"/>
    </data>
    <body>
      <for count="@urls.length">
        <body>
          <call name="Extract All Image From URL" onerror="continue">
            <data>
              <var name="url">@urls[@index]</var>
            </data>
          </call>
        </body>
      </for>
    </body>
  </function>
```
    * Further to simplify the scripting, I have added another function 'Extract All Image From all URLs' (in the same case file) which loops through the array of urls and each time makes a call to the previous function to process the url individually. <b>(Function re-usability)</b>
    * The data section defines the incoming argument as the array. It doesn't say any thing about the source of the data. Source of data needs to be defined at suite level. This gives the flexibility to change the source of incoming data any time without changing the functional logic. <b>(Data completely separated out from logic)</b>
    * Based on type of data, the function can use its properties and methods to access and modify the data at granular level.
    * The function uses a for loop with a loop count equal to the count of array items.
<br />

  * <b>Suite file - 2</b>
```
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="suite1" ref="Suite/suite1">
  <function name="Extract All Image From all URLs" ref="Script/case1/Extract All Image From all URLs">
    <data>
      <var name="urls" source="text" type="array">
        <param name="path">parse(concat(__currentpath,/data.txt))</param>
        <param name="seperationchar">parse(__newline)</param>
      </var>
    </data>
  </function>
</suite>
```
> > _Note: Although I could have called the new function with the previous suite file but I opted to create a new suite file, considering this to be a new scenario. A suite is a real executable unit. Every time we have a new execution scenario we should create a new suite file._
    * The suite calls the function 'Extract All Image From all URLs' with the required argument 'urls'. The type of the arguments should be same as in the function else the case will fail.
    * Since we are using an external file we need to provide the connection parameters along with. In above example we are using a text file to store the list of urls.
> > _Note: Framework supports the extension of any custom data source. [Read more](http://code.google.com/p/vauto/wiki/ExtendingDataSource)_
<br />

  * <b>External Data File</b>
```
  http://photo.net/editors-picks/2010/landscape-photography/
  http://photo.net/editors-picks/2010/dance-photography/
  http://sify.com/finance/search-car-imagegallery.html
  http://sify.com/finance/search-bike-imagegallery.html
```
    * This is the external data file 'data.txt' which can be placed any where on the system. The same path need to be passed given in the suite file.
    * If the requirement goes on increasing with more number of urls to be processed then we just need to keep on adding urls in the data.txt file providing <b>low maintenance cost</b>.
<br />
### Output ###
Above example collects images from the given url or list of urls.
<br />

### You may need to know ###
  * [What happens when suite file is compiled.](http://code.google.com/p/vauto/wiki/BuildingTestSuite)
  * [Scheduling Automation Script](SchedulingAutomationScript.md)
  * [Other Examples](http://code.google.com/p/vauto/wiki/Examples)