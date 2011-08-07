<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/AllCompanyDetailedReport" name="AllCompanyDetailedReport">
  <function ref="Script/case1/Rediff_ProcessAllStocks" name="Rediff_ProcessAllStocks">
    <data>
      <var onerror="break" name="dataDestination" source="text" type="datatable">
        <value><![CDATA[]]></value>
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport_{DATETIMESTAMP}.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
    </data>
  </function>
</suite>