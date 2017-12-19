using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVC_Exercise.Models
{
    public class SerializeXML<T>
    {
        
        public static T ReadFromXML()
        {
            string xml = @"<AllProjects><Proj><ProjectID>1234</ProjectID><ProjectNumber>Test Project 1</ProjectNumber><AllSubmissions><Sub Type=""Primary Submission""><SubmissionID>1</SubmissionID><SubmissionNumber>ABC_XYZ</SubmissionNumber></Sub><Sub Type=""Secondary Submission""><SubmissionID>1</SubmissionID><SubmissionNumber>ABC_XYZ_2</SubmissionNumber></Sub></AllSubmissions></Proj><Proj><ProjectID>5678</ProjectID><ProjectNumber>Test Project 2</ProjectNumber><AllSubmissions><Sub Type=""Primary Submission""><SubmissionID>1</SubmissionID><SubmissionNumber>BlahBlah</SubmissionNumber></Sub><Sub Type=""Secondary Submission""><SubmissionID>1</SubmissionID><SubmissionNumber>NadaNada</SubmissionNumber></Sub></AllSubmissions></Proj><Proj><ProjectID>9999</ProjectID><ProjectNumber>Test Project 3</ProjectNumber></Proj></AllProjects>";

            T val = default(T);
            try
            {
                // load from XML
                using (var sw = new StringReader(xml))
                {
                    var ser = new XmlSerializer(typeof(T));
                    val = (T)ser.Deserialize(sw);
                }
            }
            catch
            {
                Console.WriteLine("Problem reading from xml data file.");
            }

            return val;
        }

        //public void SaveToXML(string iPath)

        //{
        //    try
        //    {
        //        //TODO => using
        //        var sw = new StreamWriter(iPath, false, Encoding.Default);
        //        var ser = new XmlSerializer(typeof(T));
        //        ser.Serialize(sw, this);
        //        sw.Close();
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Problem saving to xml data file.");
        //    }

        //}

        //public static string XmlSerializeToString(this object objectInstance)
        //{
        //    var serializer = new XmlSerializer(objectInstance.GetType());
        //    var sb = new StringBuilder();

        //    using (TextWriter writer = new StringWriter(sb))
        //    {
        //        serializer.Serialize(writer, objectInstance);
        //    }

        //    return sb.ToString();
        //}

        //public static V XmlDeserializeFromString<V>(this string objectData)
        //{
        //    return (V)XmlDeserializeFromString(objectData, typeof(V));
        //}

        //public static object XmlDeserializeFromString(this string objectData, Type type)
        //{
        //    var serializer = new XmlSerializer(type);
        //    object result;

        //    using (TextReader reader = new StringReader(objectData))
        //    {
        //        result = serializer.Deserialize(reader);
        //    }

        //    return result;
        //}

    }
}
