using log4net;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Tool;

namespace DAL
{
    public class QuestionClassDAL
    {
        private static string NODE_NAME = "/classes/class";
        private XmlDocument xml;
        private List<QuestionClass> questionClasses;
        public string exceptionMessage;
        private string questionClassXmlPath;
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public QuestionClassDAL()
        {
            questionClassXmlPath = AppDomain.CurrentDomain.BaseDirectory + Config.GLOBAL_QUESTION_CLASSES_XML_FILE_PATH;
            exceptionMessage = loadXmlDocument();
            questionClasses = loadAllClasses();
            
        }

        public void addClass(string className)
        {
            //loadXmlDocument();
            if (xml != null)
            {
                XmlNode classList = xml.SelectSingleNode("/classes");
                XmlElement cla = xml.CreateElement("class");

                XmlElement id = xml.CreateElement("id");
                id.InnerText = (getMaxClassId()+1).ToString();
                XmlElement name = xml.CreateElement("name");
                name.InnerText = className;
                XmlElement reference = xml.CreateElement("reference");
                reference.InnerText = false.ToString();

                cla.AppendChild(id);
                cla.AppendChild(name);
                cla.AppendChild(reference);
                classList.AppendChild(cla);
                xml.Save(questionClassXmlPath);
            }

            logger.Info("test info");
        }

        public void deleteClass(string classID)
        {
            //loadXmlDocument();
            if (xml != null)
            {
                XmlNodeList nodelist = xml.SelectSingleNode("/classes").ChildNodes;

                foreach (XmlNode node in nodelist)
                {
                    XmlNodeList childNodes = node.ChildNodes;
                    if (childNodes.Item(0).InnerText.Equals(classID))
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
                xml.Save(questionClassXmlPath);
            }
            
        }

        public bool checkIsReference(string classID)
        {
            if (xml != null)
            {
                XmlNodeList nodelist = xml.SelectSingleNode("/classes").ChildNodes;

                foreach (XmlNode node in nodelist)
                {
                    XmlNodeList childNodes = node.ChildNodes;
                    if (childNodes.Item(0).InnerText.Equals(classID))
                    {
                        return bool.Parse(childNodes.Item(2).InnerText);
                    }
                }
            }

            return false;
        }

        private int getMaxClassId()
        {
            int maxId = 0;
            for (int i = 0; i < questionClasses.Count; i++)
            {
                if (questionClasses[i].classID > maxId)
                {
                    maxId = questionClasses[i].classID;
                }
            }
            return maxId;
        }

        private string loadXmlDocument()
        {
            try
            {
                xml = new XmlDocument();

                //string xmlNamespace = "DAL";
                //string xmlPath = "DAL.question_classes.question_classes.xml";
                //Assembly myAssembly = Assembly.Load(xmlNamespace);
                //Stream strm = myAssembly.GetManifestResourceStream(xmlPath);

                if (File.Exists(questionClassXmlPath))
                {
                    //currentDirectory + Config.GLOBAL_QUESTION_CLASSES_XML_FILE_PATH
                    xml.Load(questionClassXmlPath);
                    
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                return ex.ToString();
            }

            return null;
        }

        public List<QuestionClass> loadAllClasses()
        {
            loadXmlDocument();

            List<QuestionClass> questionClassesList = new List<QuestionClass>();

            if (xml != null)
            {
                XmlNodeList nodelist = xml.SelectNodes(NODE_NAME);
                if (nodelist != null)
                {
                    foreach (XmlNode node in nodelist)
                    {
                        QuestionClass questionClass = new QuestionClass();

                        XmlNodeList childNodes = node.ChildNodes;
                        questionClass.classID = int.Parse(childNodes.Item(0).InnerText);
                        questionClass.className = childNodes.Item(1).InnerText;
                        questionClass.isReferences = bool.Parse(childNodes.Item(2).InnerText);

                        questionClassesList.Add(questionClass);
                    }
                }
            }

            return questionClassesList;
        }
    }
}
