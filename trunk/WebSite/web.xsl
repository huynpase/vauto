<xsl:stylesheet id="style1" version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="/">
  <html>
  	<body style="font-family: Arial,Helvetica,sans-serif; font-size: 12px;">
  		<xsl:value-of select="//vibz/."/>
  
  	</body>
  </html>
 </xsl:template>
</xsl:stylesheet>