using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInteraction
{
    using System.IO;

    using SocialNetwork;

    [Serializable]
    public class FileInteraction : IPandaSocialNetworkStorageProvider
    {
        // TODO : implement writing
        public bool Save(SocialNetwork network)
        {
            StreamWriter str = new StreamWriter("..\\..\\..\\Network.txt");
            using (str)
            {
                str.WriteLine();
            }

            return true;
        }

        public SocialNetwork Load()
        {
            throw new NotImplementedException();
        }
    }
}
