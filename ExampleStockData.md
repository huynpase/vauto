[Download Source](http://vauto.googlecode.com/files/StockMarket.zip) - [Download VACS](http://vauto.googlecode.com/files/StockMarketVacs.zip)

### Pre-requisite ###
  * Vibz Automation Framework. [Download here](http://code.google.com/p/vauto/downloads/list?can=3&q=&colspec=Filename+Summary+Uploaded+Size+DownloadCount)

### Pre-knowledge ###
  * [Case file format](http://code.google.com/p/vauto/wiki/UsingVibzAutomationStudio#Writing_case_function)

### Description ###
The source files can be viewed through Vibz Automation Studio or in any editor. The source contains project files, a script folder and a suite folder. Script folder is where you can find the case file and identifier files. Suite folder contains the test suite file. There is a bin/Debug in the source folder which has compiled script (VACS) file.<br />
The Vacs (Vibz automation compiled script), is portable, self contained executable file that can be executed on any remote machine where Vibz Automation framework (VAF) is installed.<br />
Lets see the code in detail;<br />
  * <b>Case file</b>
    * Function <b>GetStockDetailedData</b>.
```
  <function name="GetStockDetailedData">
    <include id="case1.id"></include>
    <data>
	<var name="url"></var>
	<var name="comp_name"></var>
	<var name="result" type="datatable"></var>
    </data>
    <body>
1.	<openurl url="@url"/>
2.	<set var="comp_name" value="@comp_name" />
3.	<getattribute locator="$perfImgLoc" assignto="perfImgLoc" />
4.	<invoke assignto="index1" method="@perfImgLoc.lastindexof(/)" />
5.	<set var="index1" value="parse(sum(@index1,1))" />
6.	<invoke assignto="index2" method="@perfImgLoc.lastindexof(.)" />
7.	<set var="length" value="parse(substract(@index2,@index1))" />
8.	<invoke method="@perfImgLoc.substring(@index1, @length)" assignto="abc" />			
9.	<getattribute locator="$iframeLoc" assignto="iframeSrc" />
10.	<openurl url="@iframeSrc" />
11.	<getinnertext locator="$curVal" assignto="curVal" />
12.	<getinnertext locator="$changeVal" assignto="changeVal" />
13.	<getinnertext locator="$perchangeVal" assignto="perchangeVal" />
14.	<invoke method="@result.AddRow(@comp_name,@curVal, @changeVal,@perchangeVal , @abc)" />
    </body>
  </function>
```
      * Function _GetStockDetailedData_ goes through rediff finance page to extract the required data.
      * The function accepts three arguments: page url, company name and the destination point.
      * All the used instructions are available either in Vibz.Web or Vibz.IO. The suite has referenced these modules.
      * First instruction opens the url in a browser and successive instructions goes to fetch the data from the page.
      * The value for 'How hot is the stock' is being derived from an image url. Instructions 2 - 8 does some string manipulations to get the value from the url. (This string manipulation doesn't fall in the plain logic of the testcase. So we may move this function as a separate function.)
      * Next data is into an iframe. Instruction at 9 fetches the iframe url.
      * Line 10 - 13 fetches the data from the iframe.
      * Line 14 pushes all the fetched data into a datatable.
      * The objective of the function is collect the data and push it into a datatable which acts as out variable.
    * Function <b>ProcessSourceStocks</b>.
```
  <function name="ProcessSourceStocks">
    <include id="case1.id"></include>
    <data>
	<var name="url"></var>
	<var name="stockSource" type="datatable"></var>
	<var name="dataDestination" type="datatable"></var>
    </data>
    <body>
	<define var="result" type="datatable" />
	<for count="@stockSource.rowcount">
        	<body>
			<call name="GetStockDetailedData">
        			<data>
			        	<var name="url">parse(replace(replace(@url, {comp_name},@stockSource[@index][0] ), {comp_code},@stockSource[@index][1] ))</var>
			        	<var name="comp_name">@stockSource[@index][0]</var>
					<var name="result">@result</var>
        			</data>
      			</call>
	        </body>
      	</for>
	<export destination="@dataDestination" source="@result" mode="update"/>
    </body>
  </function>
```
      * Function 'ProcessSourceStocks' uses an input file that contains the company information in a table structure.
      * It uses the information to create a url and passes the url to previous function which then extracts the required data.
      * One can put all the companies info at one single file to fetch the data.
      * _export_ instruction exports the fetched data into the destination location.
    * Function <b>ProcessAllStocks</b>.
```
  <function name="ProcessAllStocks">
    <include id="case1.id"></include>
    <data>
	<var name="url"></var>
	<var name="mode">insert</var>
	<var name="dataDestination" type="datatable"></var>
    </data>
    <body>
	<openurl url="@url" onerror="continue"/>
	<gettablecontent repeaterxpath="$repeaterXPath" columnxpathset="$columnXPathSet" xpathseperator="$xPathSeperator" assignto="data" onerror="continue"/>
	<define var="result" type="datatable" />
	<for count="@data.rowcount">
        	<body>
			<call name="GetStockDetailedData" onerror="continue">
        			<data>
			        	<var name="url">@data[@index][3]</var>
			        	<var name="comp_name">@data[@index][0]</var>
					<var name="result">@result</var>
        			</data>
      			</call>
	        </body>
      	</for>
	<export destination="@dataDestination" source="@result" mode="@mode"/>
    </body>
  </function>
```
      * Function 'ProcessAllStocks' is an extension to 'ProcessSourceStocks' where it doesnt depend on the input urls. Rather it fetches the urls from the site itself and then processes each url sequentially.
      * Instruction Export has three properties.
        * The source of data. This can be a variable or a external source.
        * Destination where data need to be exported.
        * Mode: When insert with append to existing recordset and when update will overwrite new recordset to the destination specified.
<br />
  * <b>Identifier file</b>
```
<controls xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	 <control name="repeaterXPath"><![CDATA[//table[@class='dataTable']/tbody/tbody/tr]]></control>
	 <control name="columnXPathSet"><![CDATA[{td[1]/a/text()}{td[4]/text()}{td[5]/font/text()}{td[1]/a/@href}]]></control>
	 <control name="xPathSeperator"><![CDATA[{,}]]></control>
	 <control name="iframeLoc"><![CDATA[//iframe[@id='current']/@src]]></control>
	 <control name="curVal"><![CDATA[//span[@id='ltpid']]]></control>
	 <control name="changeVal"><![CDATA[//span[@id='change']]]></control>
	 <control name="perchangeVal"><![CDATA[//span[@id='ChangePercent']]]></control>
	 <control name="perfImgLoc"><![CDATA[//img[@width='154' and @height='89']/@src]]></control>
</controls>
```
    * The identifier file defines the locators that were used by the testcase to reach a control.
    * The module 'Vibz.Web' supports xpath to access a control, hence the locators defined here are XPaths.
<br />
  * <b>Suite file</b>
    * <b>CompanyUpdate.ts</b>
```
<function name="ProcessSourceStocks" ref="Script/case1/ProcessSourceStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">http://money.rediff.com/companies/{comp_name}/{comp_code}</var>
      <var name="stockSource" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/company.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/data.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
    </data>
  </function>
```
      * Suite file 'CompanyUpdate.ts' calls the test case 'ProcessSourceStocks' with argument values being passed to it.
    * <b>AllCompanyDetailedReport.ts</b>
```
 <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupa]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[update]]></Value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <Value><![CDATA[]]></Value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
  ...
```
      * Suite file 'AllCompanyDetailedReport.ts' calls the test case 'ProcessAllStocks' multiple times with different base urls where it can look for url of the companies.
### Output ###
Above example collects stock data from the host site.
<br />

### You may need to know ###
  * [What happens when suite file is compiled.](http://code.google.com/p/vauto/wiki/BuildingTestSuite)
  * [Scheduling Automation Script](SchedulingAutomationScript.md)
  * [Other Examples](http://code.google.com/p/vauto/wiki/Examples)