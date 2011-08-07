<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/CompanyUpdate" name="CompanyUpdate">
  <function ref="Script/case1/ProcessSourceStocks" name="ProcessSourceStocks">
    <data>
      <var onerror="break" name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/companies/{comp_name}/{comp_code}]]></value>
      </var>
      <var onerror="break" name="stockSource" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/company.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
      <var onerror="break" name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/SourceDetailedReport_{DATETIMESTAMP}.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>