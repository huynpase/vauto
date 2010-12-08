<?xml version="1.0" encoding="utf-8"?>
<suite xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="suite2" ref="Suite/suite2">
  <function name="Extract All Image From all URLs" ref="Script/case1/Extract All Image From all URLs">
    <data>
      <var name="urls" source="text" type="array">
        <param name="path">parse(concat(__currentpath,/data.txt))</param>
        <param name="seperationchar">parse(__newline)</param>
        <Value><![CDATA[]]></Value>
      </var>
    </data>
  </function>
</suite>