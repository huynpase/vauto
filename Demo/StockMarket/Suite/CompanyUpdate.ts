<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CompanyUpdate" ref="Suite/CompanyUpdate">
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
</suite>