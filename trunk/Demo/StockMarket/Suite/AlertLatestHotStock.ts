<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/AlertLatestHotStock" name="AlertLatestHotStock">
  <function ref="Script/case1/AlertLatestHotStocks" name="AlertLatestHotStocks">
    <data>
      <var onerror="break" name="directory" source="internal" type="scalar">
        <value><![CDATA[parse(__currentpath)]]></value>
      </var>
      <var onerror="break" name="dataDestination" source="text" type="keyvalueset">
        <param name="path">parse(concat(__currentpath,/StockData/HotStock.txt))</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>