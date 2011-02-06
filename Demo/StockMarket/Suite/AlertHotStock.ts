<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/AlertHotStock" name="AlertHotStock">
  <function ref="Script/case1/AlertHotStocks" name="AlertHotStocks">
    <data>
      <var name="dataSource" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/CompanyDetailedReport_02Feb.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
      <var name="dataDestination" source="text" type="keyvalueset">
        <param name="path">parse(concat(__currentpath,/StockData/HotStock.txt))</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>