using System;
using System.Collections.Generic;
using System.Linq;
using Panda;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace FileInteraction
{
    using System.IO;

    using SocialNetwork;

    [Serializable]
    public class JSONStorageProvider : IPandaSocialNetworkStorageProvider
    {
        private const string Filepath = "..\\..\\..\\Pandas.json";

        public void Save(SocialNetwork network)
        {
            this.PandaSave(network.GetPandas().ToList());
        }

        private void PandaSave(List<IPanda> pandas)
        {
            var serializer = new JavaScriptSerializer();
            var serialized = serializer.Serialize(pandas);
            using (StreamWriter str = new StreamWriter(Filepath))
            {
                str.WriteLine(serialized);
            }
        }

        public SocialNetwork Load()
        {
            var socialNetwork = new SocialNetwork();
            foreach (var panda in this.LoadPanda(Filepath))
            {
                socialNetwork.AddPanda(panda);
            }

            return socialNetwork;
        }

        private IList<IPanda> LoadPanda(string filePath)
        {
            var deserializer = new JavaScriptSerializer();
            var stillSerialized = File.ReadAllText(filePath);
            return deserializer.Deserialize<List<IPanda>>(stillSerialized);
        }
    }
}
