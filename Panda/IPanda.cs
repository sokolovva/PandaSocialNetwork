namespace Panda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPanda
    {
        string Name { get; set; }

        string Email { get; set; }

        Gender Gender { get; set; }

        bool IsMale { get; set; }

        bool IsFemale { get; set; }


    }
}
