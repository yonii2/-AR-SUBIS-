using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LoadXML : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public TMP_Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
    }

    void parseXmlFile(string xmlData)
    {
        string totVal = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load (new StringReader(xmlData));

        string xmlPathPattern = "//response/body";
        XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach (XmlNode node in xmlNodeList) 
        {
            XmlNode name = node.FirstChild;
            XmlNode addr = name.NextSibling;
            XmlNode phone = addr.NextSibling;

            totVal = "Name : " + name.InnerXml + "\n Address : " + addr.InnerXml;
            uiText.text = totVal;
        }
    }
}
