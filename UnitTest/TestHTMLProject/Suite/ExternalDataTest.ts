<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ExternalDataTest" ref="Suite/ExternalDataTest">
  <function name="scalar_data" ref="Script/ExternalData/exdata/scalar_data">
    <data>
      <var name="file">C:\Amit\Auto mate\UnitTest\exdata/destination_scalar.txt</var>
      <var name="dataSource" source="text" type="scalar">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
      </var>
      <var name="dataDestination" source="text" type="scalar">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_scalar_write.txt</param>
      </var>
    </data>
  </function>
  <function name="array_data_forloop" ref="Script/ExternalData/exdata/array_data_forloop">
    <data>
      <var name="file" source="Internal" type="Scalar">C:\Amit\Auto mate\UnitTest\exdata/destination_array_general.txt</var>
      <var name="data1" source="text" type="array">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
      </var>
      <var name="dataDestination" source="text" type="array">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_array_write.txt</param>
      </var>
    </data>
  </function>
  <function name="array_data_forloop" ref="Script/ExternalData/exdata/array_data_forloop">
    <data>
      <var name="file" source="Internal" type="Scalar">C:\Amit\Auto mate\UnitTest\exdata/destination_array_forloop.txt</var>
      <var name="data1" source="text" type="array">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
        <param name="seperationchar">parse(__tab)</param>
      </var>
      <var name="dataDestination" source="text" type="array">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_array_sep_write.txt</param>
      </var>
    </data>
  </function>
  <function name="datatable_data_forloop" ref="Script/ExternalData/exdata/datatable_data_forloop">
    <data>
      <var name="file" source="Internal" type="Scalar">C:\Amit\Auto mate\UnitTest\exdata/destination_datatable.txt</var>
      <var name="data1" source="text" type="datatable">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
        <param name="rowseperationchar">parse(__newline)</param>
        <param name="colseperationchar">parse(__tab)</param>
      </var>
      <var name="dataDestination" source="text" type="datatable">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_datatable_write.txt</param>
      </var>
    </data>
  </function>
  <function name="keyvalue_data_general" ref="Script/ExternalData/exdata/keyvalue_data_general">
    <data>
      <var name="file" source="Internal" type="Scalar">C:\Amit\Auto mate\UnitTest\exdata/destination_keyvalue.txt</var>
      <var name="data1" source="text" type="keyvalueset">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
        <param name="listseperationchar">parse(__newline)</param>
        <param name="itemseperationchar">parse(__tab)</param>
      </var>
      <var name="dataDestination" source="text" type="keyvalueset">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_keyvalueset_write.txt</param>
      </var>
    </data>
  </function>
  <function name="scalar_data" ref="Script/ExternalData/exdata/scalar_data">
    <data>
      <var name="file" source="Internal" type="Scalar">C:\Amit\Auto mate\UnitTest\exdata/destination_scalar.txt</var>
      <var name="dataSource" source="text" type="scalar">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/source.txt</param>
      </var>
      <var name="dataDestination" source="text" type="array">
        <param name="path">C:\Amit\Auto mate\UnitTest\exdata/destination_scalar_neg_write.txt</param>
      </var>
    </data>
  </function>
</suite>