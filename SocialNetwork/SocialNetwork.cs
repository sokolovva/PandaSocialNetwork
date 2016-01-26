namespace SocialNetwork
{
    using Panda;
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SocialNetwork
    {
        readonly Dictionary<IPanda, List<int>> pandasInNetwork = new Dictionary<IPanda, List<int>>();

        public void AddPanda(IPanda panda)
        {
            try
            {
                if (!this.pandasInNetwork.ContainsKey(panda))
                {
                    this.pandasInNetwork.Add(panda, new List<int>());
                }
                else
                {
                    throw new PandasAlreadyExists();
                }
            }
            catch (PandasAlreadyFriendsException)
            {
                // TODO : remove message below?
                Console.WriteLine("Panda already has been added");
            }
        }

        public bool HasPanda(IPanda panda)
        {
            return this.pandasInNetwork.ContainsKey(panda);
        }

        // TODO : check logic - add pandas as friends rather Nodes?
        public void MakeFriends(IPanda panda1, IPanda panda2)
        {
            // TODO : check which panda misses
            if (!(this.pandasInNetwork.ContainsKey(panda1)))
            {
                this.pandasInNetwork.Add(panda1, new List<int>());
            }

            if (!(this.pandasInNetwork.ContainsKey(panda2)))
            {
                this.pandasInNetwork.Add(panda2, new List<int>());
            }

            // TODO : fix check for already friends
            if (!this.pandasInNetwork[panda1].Contains(panda2.GetHashCode()) && !this.pandasInNetwork[panda2].Contains(panda1.GetHashCode()))
            {
                this.pandasInNetwork[panda1].Add(panda2.GetHashCode());
                this.pandasInNetwork[panda2].Add(panda1.GetHashCode());
            }
            else
            {
                throw new PandasAlreadyFriendsException();
            }
        }

        // TODO : logic - check if panda1 is in panda2's friends list and vice-versa
        public bool AreFriend(IPanda panda1, IPanda panda2)
        {
            /*bool IsFriend = true;
             Node friendNode1, friendNode2;
             if (PandasInNetwork.ContainsKey(panda1)&& PandasInNetwork.ContainsValue(friendNode1)))
             {
             nopenopenope TODOOO

             }*/
            return true;
        }
    }
}