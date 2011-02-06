<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/CompanyUpdate" name="CompanyUpdate">
  <function ref="Script/case1/ProcessSourceStocks" name="ProcessSourceStocks">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <value><![CDATA[http://money.rediff.com/companies/{comp_name}/{comp_code}]]></value>
      </var>
      <var name="stockSource" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/company.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">parse(concat(__currentpath,/data.txt))</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
        <value><![CDATA[]]></value>
      </var>
    </data>
  </function>
</suite>