<xsl:stylesheet id="style1" version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="//vibz">
  <html>
  	<body style="margin: 0; font-family: Arial,Helvetica,sans-serif; font-size: 12px;">
      <div style="float: none;width: 100%;">
        <div style="float: left">
          <table>
            <tr>
              <td>
                <img style="float: left" src="http://code.google.com/p/vauto/logo?cct=1291777797" alt="Vibzworld Presentation"></img>
              </td>
              <td style="vertical-align: bottom">
                <font face="Verdana, Arial, Helvetica, sans-serif" size="4">
                  <xsl:value-of select="@heading"/>
                </font>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div style="float: none">
        <xsl:for-each select="section">
          <div style="float: left">
            <table border="0" cellspacing="0" cellpadding="2" align="center" height="200">
              <tr valign="middle">
                <td width="200" height="20">
                  <xsl:attribute name="bgcolor">
                    <xsl:value-of select="@color" />
                  </xsl:attribute>
                  <div style="padding-left: 20px">
                    <font color="#FFFFFF">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          <xsl:value-of select="header/."/>
                        </font>
                      </b>
                    </font>
                  </div>
                </td>
              </tr>
              <tr valign="top">
                <td width="200">
                  <xsl:attribute name="bgcolor">
                    <xsl:value-of select="@color" />
                  </xsl:attribute>
                  <table width="100%" border="0" cellspacing="0" cellpadding="3" height="180">
                    <tr bgcolor="#FFFFFF" valign="top">
                      <td>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                        <ul>
                          <xsl:for-each select="content/item">
                            <li>
                              <xsl:choose>
                                <xsl:when test="@type='link'">
                                  <a style="cursor: pointer;">
                                    <xsl:attribute name="onclick">
                                      javascript:window.open('<xsl:value-of select="@url" />','');
                                    </xsl:attribute>
                                    <font color="blue">
                                      <xsl:value-of select="."/>
                                    </font>
                                  </a>
                                </xsl:when>
                                <xsl:otherwise>
                                  <xsl:value-of select="."/>
                                </xsl:otherwise>
                              </xsl:choose>
                            </li>
                          </xsl:for-each>
                        </ul>
                        </font>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </div>
          <div style="float: left; width: 20px;"></div>
        </xsl:for-each>
      </div>
  	</body>
  </html>
 </xsl:template>
</xsl:stylesheet>