namespace FileInteraction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialNetwork;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPandaSocialNetworkStorageProvider
    {
        void Save(SocialNetwork network);

        SocialNetwork Load();
    }
}
