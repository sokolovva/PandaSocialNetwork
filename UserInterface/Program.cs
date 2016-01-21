namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var panda = new Panda("goshko", "emaiddl@gmail.com", Gender.Male);
            Console.WriteLine(panda.ToString());
        }
    }
}
