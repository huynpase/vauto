<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="suite1" ref="Suite/suite1">
  <function name="Extract All Image From URL" ref="Script/case1/Extract All Image From URL">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://sify.com/finance/search-car-imagegallery.html]]></Value>
      </var>
    </data>
  </function>
  <function name="Extract All Image" ref="Script/case1/Extract All Image">
    <data>
      <var name="url" source="Internal" type="Scalar">
        <Value><![CDATA[http://sify.com/finance/search-bike-imagegallery.html]]></Value>
      </var>
    </data>
  </function>
</suite>