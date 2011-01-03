using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Interpreter.Plugin;
using System.Xml;
using Vibz.Contract.Attribute;

namespace Vibz.Interpreter.Document
{
    public static class Doc
    {

        public static XmlDocument XmlDocument
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                XmlElement ele = doc.CreateElement("APIContent");
                foreach (PluginType pType in new PluginType[] { PluginType.Instruction, PluginType.Macro })
                {
                    XmlElement typeEle = doc.CreateElement("pluginset");

                    XmlAttribute tattr = doc.CreateAttribute("type");
                    tattr.Value = pType.ToString();
                    typeEle.Attributes.Append(tattr);

                    PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(pType);
                    foreach (PluginAssemblyInfo pInfo in list)
                    {
                        XmlElement pluginEle = doc.CreateElement("plugin");

                        XmlAttribute pattr = doc.CreateAttribute("name");
                        pattr.Value = pInfo.Name;
                        pluginEle.Attributes.Append(pattr);

                        foreach (string key in pInfo.Keys)
                        {
                            XmlElement eEle = doc.CreateElement("element");
                            
                            XmlAttribute eattr = doc.CreateAttribute("name");
                            eattr.Value = pInfo[key].TypeName;
                            eEle.Attributes.Append(eattr);

                            eattr = doc.CreateAttribute("type");
                            eattr.Value = pInfo[key].Type;
                            eEle.Attributes.Append(eattr);

                            eattr = doc.CreateAttribute("version");
                            eattr.Value = pInfo[key].Information.Version;
                            eEle.Attributes.Append(eattr);

                            eattr = doc.CreateAttribute("author");
                            eattr.Value = pInfo[key].Information.Author;
                            eEle.Attributes.Append(eattr);

                            XmlElement edEle = doc.CreateElement("detail");
                            XmlCDataSection detail = doc.CreateCDataSection(pInfo[key].Information.Details);
                            edEle.AppendChild(detail);
                            eEle.AppendChild(edEle);

                            XmlElement aEleList = doc.CreateElement("attributes");
                            foreach (FunctionAttribute attr in pInfo[key].Attributes)
                            {
                                XmlElement aEle = doc.CreateElement("attribute");

                                XmlAttribute aattr = doc.CreateAttribute("name");
                                aattr.Value = attr.Name;
                                aEle.Attributes.Append(aattr);

                                aattr = doc.CreateAttribute("required");
                                aattr.Value = attr.IsRequired.ToString().ToLower();
                                aEle.Attributes.Append(aattr);

                                XmlElement adEle = doc.CreateElement("detail");

                                XmlCDataSection adetail = doc.CreateCDataSection(attr.Detail);
                                adEle.AppendChild(adetail);

                                aEle.AppendChild(adEle);
                                if (attr.Options != null)
                                {
                                    XmlElement aosEle = doc.CreateElement("options");

                                    foreach (string opt in attr.Options)
                                    {
                                        XmlElement aoEle = doc.CreateElement("option");

                                        XmlCDataSection aoEleText = doc.CreateCDataSection(opt);
                                        aoEle.AppendChild(aoEleText);

                                        aosEle.AppendChild(aoEle);
                                    }
                                    aEle.AppendChild(aosEle);
                                }
                                aEleList.AppendChild(aEle);
                            }
                            eEle.AppendChild(aEleList);

                            pluginEle.AppendChild(eEle);
                        }
                        typeEle.AppendChild(pluginEle);
                    }
                    ele.AppendChild(typeEle);
                }
                doc.AppendChild(ele);
                return doc;
            }
        }
    }
}
