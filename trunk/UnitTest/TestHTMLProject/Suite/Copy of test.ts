<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="test" ref="Suite/test">
  <function name="main" ref="Script/HTML/testhtml/main">
    <data>
      <var name="url" source="internal" type="scalar">C:\Amit\Auto mate\Document\TestHTML\Controls.htm</var>
      <var name="file1" source="internal" type="scalar">C://Amit/write_a.htm</var>
      <var name="data1" source="internal" type="scalar">text1</var>
      <var name="data2" source="internal" type="scalar">text2</var>
      <var name="data3" source="internal" type="scalar">pass1</var>
      <var name="data4" source="internal" type="scalar">pass2</var>
      <var name="data5" source="internal" type="scalar">C://Amit/write_b.htm</var>
      <var name="data6" source="internal" type="scalar">3</var>
      <var name="data7" source="internal" type="scalar">4</var>
    </data>
  </function>
  <function name="test2" ref="Script/HTML/SUBHTML/shtml/test2">
    <data />
  </function>
  <suite name="NegativeTest" ref="Suite/NegativeTest" />
  <function name="scalar_data" ref="Script/ExternalData/exdata/scalar_data">
    <data>
      <var name="data1" source="text" type="scalar">
        <param name="path">C:/automate/scalar_data/source.txt</param>
      </var>
    </data>
  </function>
</suite>