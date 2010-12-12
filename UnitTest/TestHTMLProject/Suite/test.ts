<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="test" ref="Suite/test">
  <function name="main" ref="Script/HTML/testhtml/main">
    <data>
      <var name="url" source="internal" type="scalar">
        <value><![CDATA[C:\Amit\Auto mate\UnitTest\TestWebSite\Controls.htm]]></value>
      </var>
      <var name="file1" source="internal" type="scalar">
        <value><![CDATA[C://Amit/write_a.htm]]></value>
      </var>
      <var name="data1" source="internal" type="scalar">
        <value><![CDATA[text1]]></value>
      </var>
      <var name="data2" source="internal" type="scalar">
        <value><![CDATA[text2]]></value>
      </var>
      <var name="data3" source="internal" type="scalar">
        <value><![CDATA[pass1]]></value>
      </var>
      <var name="data4" source="internal" type="scalar">
        <value><![CDATA[pass2]]></value>
      </var>
      <var name="data5" source="internal" type="scalar">
        <value><![CDATA[C://Amit/write_b.htm]]></value>
      </var>
      <var name="data6" source="internal" type="scalar">
        <value><![CDATA[3]]></value>
      </var>
      <var name="data7" source="internal" type="scalar">
        <value><![CDATA[4]]></value>
      </var>
    </data>
  </function>
  <function name="test2" ref="Script/HTML/SUBHTML/shtml/test2">
    <data />
  </function>
  <suite name="NegativeTest" ref="Suite/NegativeTest" />
  <suite name="ExternalDataTest" ref="Suite/ExternalDataTest" />
</suite>