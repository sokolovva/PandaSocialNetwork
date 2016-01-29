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
        public void Save(SocialNetwork network)
        {
            this.PandaSave(network.GetPandas().ToList());
        }

        private void PandaSave(List<IPanda> pandas)
        {
            var serializer = new JavaScriptSerializer();
            var serialized = serializer.Serialize(pandas);
            using (StreamWriter str = new StreamWriter("..\\..\\..\\Pandas.json"))
            {
                str.WriteLine(serialized);
            }
        }

        public SocialNetwork Load()
        {
            throw new NotImplementedException();
        }
    }
}
