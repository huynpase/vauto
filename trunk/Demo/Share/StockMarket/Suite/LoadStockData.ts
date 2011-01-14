<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="LoadStockData" ref="Suite/LoadStockData">
  <function name="RecordDayData" ref="Script/case1/RecordDayData">
    <data>
      <var name="url" source="Internal" type="Scalar">http://money.rediff.com/gainers</var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">C:\Amit\StockData\gainers.txt</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
    </data>
  </function>
  <function name="RecordDayData" ref="Script/case1/RecordDayData">
    <data>
      <var name="url" source="Internal" type="Scalar">http://money.rediff.com/losers</var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">C:\Amit\StockData\losers.txt</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
    </data>
  </function>
</suite>