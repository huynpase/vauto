<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" ref="Suite/suite1" name="suite1">
  <function ref="Script/case1/Say Hello" name="Say Hello">
    <data>
      <var onerror="break" name="message" source="Internal" type="Scalar">
        <value><![CDATA[Hello World]]></value>
      </var>
    </data>
  </function>
</suite>