using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLReference
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDeclarationXMLReferenceList();
        }

        public static void GetDeclarationXMLReferenceList()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}Declaration.xml";
            List<string> listOfResult = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList xml = doc.SelectNodes("/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference");
            foreach (XmlNode node in xml)
            {
                var refCode = node.Attributes["RefCode"].InnerText;

                switch (refCode)
                {
                    case "MWB":
                        listOfResult.Add($"MWB - {node.FirstChild.InnerText}");
                        break;
                    case "TRV":
                        listOfResult.Add($"TRV - {node.FirstChild.InnerText}");
                        break;
                    case "CAR":
                        listOfResult.Add($"CAR - {node.FirstChild.InnerText}");
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in listOfResult)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
