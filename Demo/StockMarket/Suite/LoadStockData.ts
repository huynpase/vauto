<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/LoadStockData" name="LoadStockData">
  <function ref="Script/case1/RecordDayData" name="RecordDayData">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/gainers]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">C:\Amit\StockData\gainers.txt</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
  <function ref="Script/case1/RecordDayData" name="RecordDayData">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/losers]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">C:\Amit\StockData\losers.txt</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>