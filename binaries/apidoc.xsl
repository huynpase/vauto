<xsl:stylesheet id="style1" version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="/">
   <html>
     <body style="font-family: Arial,Helvetica,sans-serif; font-size: 12px;">
       <h2>
         <center>
           <xsl:value-of select="//Document/title"/>
         </center>
       </h2>
       <br/>
       <h3>
         <center>
           <xsl:value-of select="//Document/copyright"/>
           <br/>
           <xsl:value-of select="//Document/version"/>
           : <xsl:value-of select="//Document/frameversion"/>
         </center>
       </h3>
       <hr />
       <br/>
       <xsl:value-of select="//Document/preface"/>
       <br/>
       <br/>
       <i>
         <xsl:value-of select="//Document/note"/>
       </i>
       <table style="width: 100%; border: 0px;">
         <xsl:for-each select="//Document/APIContent/pluginset">
           <tr>
             <td>
               <br/>
               <h3 style="background-color: #2060a7; padding: 5px;">
                 <font color="white">
                   <xsl:value-of select="@type"/>
                 </font>
               </h3>
               <hr/>
               <ul>
                 <xsl:for-each select="plugin">
                   <li>
                     <h4>
                       <h3 style="background-color: #e0e0e0; padding: 3px;">
                         <xsl:value-of select="@name"/>
                       </h3>
                     </h4>
                   </li>
                   <ul>
                     <xsl:for-each select="element">
                       <li>
                         <span style="background-color: #f0f0f0; padding: 2px; font-family: Arial,Helvetica,sans-serif; font-size: 12px; width: 100%">
                           <b><xsl:value-of select="@name"/> - <xsl:value-of select="//Document/version"/>:<xsl:value-of select="@version"/>
                           </b>
                         </span>
                       </li>
                       <br/>
                       <span style="font-family: Arial,Helvetica,sans-serif; font-size: 12px;">
                         <b>
                           <xsl:value-of select="//Document/author"/>:
                         </b>
                         <xsl:value-of select="@author"/>
                         <br/>
                         <xsl:value-of select="detail/."/>
                         <br/>
                         <xsl:if test="count(attributes/attribute) &gt; 0">
                           <b>
                             <xsl:value-of select="//Document/properties"/>:
                           </b>
                           <ul>
                             <xsl:for-each select="attributes/attribute">
                               <li>
                                 <b>
                                   <xsl:value-of select="@name"/>
                                 </b>
                               </li>
                               <xsl:if test="@required != 'true'">
                                  [Optional]
                               </xsl:if>
                                 : <xsl:value-of select="detail/."/>
                               <xsl:if test="count(options/option) &gt; 0">
                                 <br/>
                                 <b>Allowed options: </b>
                                 <ul>
                                   <xsl:for-each select="options/option">
                                     <li>
                                       <xsl:value-of select="."/>
                                     </li>
                                   </xsl:for-each>
                                 </ul>
                               </xsl:if>
                             </xsl:for-each>
                           </ul>
                         </xsl:if>
                         <br/>
                       </span>
                     </xsl:for-each>
                   </ul>
                 </xsl:for-each>
               </ul>
             </td>
           </tr>
         </xsl:for-each>
       </table>
     </body>
   </html>
 </xsl:template>
 <xsl:template match="xsl:stylesheet">
  <!-- ignore -->
 </xsl:template>
</xsl:stylesheet>