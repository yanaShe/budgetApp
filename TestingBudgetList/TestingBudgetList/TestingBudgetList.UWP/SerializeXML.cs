using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestingBudgetList.Data;
using TestingBudgetList.Models;
using TestingBudgetList.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SerializeXML))]
namespace TestingBudgetList.UWP
{
    public class SerializeXML : ISerialization
    {
        public SerializeXML()
        {

        }
        public void SerializeObject(List<Exapnses> expanse)
        {
            var serializer = new XmlSerializer(typeof(List<Exapnses>));
            //var filePath = ApplicationContext.FilesDir.AbsolutePath + "/Expanse.xml"
            var Filename = "Expanses.xml";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, Filename);
            var fs = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                serializer.Serialize(streamWriter, expanse);

            }

        }

        public List<Exapnses> Deserialize()
        {
            var serializer = new XmlSerializer(typeof(List<Exapnses>));
            var Filename = "Expanses.xml";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, Filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Exapnses> expanse = (List<Exapnses>)serializer.Deserialize(fs);
                return expanse;
            }
        }
    }

    }

