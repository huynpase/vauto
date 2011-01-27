<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AllCompanyDetailedReport" ref="Suite/AllCompanyDetailedReport">
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupa]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[update]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupb]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groups]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupt]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupts]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers/bse/daily/groupz]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groupa]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groupb]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groups]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groupt]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groupts]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function name="ProcessAllStocks" ref="Script/case1/ProcessAllStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers/bse/daily/groupz]]></value>
      </var>
      <var name="mode" source="Internal" type="Scalar">
        <value><![CDATA[insert]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>