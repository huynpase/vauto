<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AllCompanyDetailedReport" ref="Suite/AllCompanyDetailedReport">
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupb]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groups]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupt]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupts]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupz]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groupa]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groupb]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groups]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groupt]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groupts]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
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
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://money.rediff.com/losers/bse/daily/groupz]]></Value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <Value><![CDATA[insert]]></Value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <Value><![CDATA[]]></Value>
      </var>
    </data>
  </function>
</suite>