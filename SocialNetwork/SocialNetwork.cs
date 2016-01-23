namespace SocialNetwork
{
    using Panda;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SocialNetwork
    {
        readonly Dictionary<IPanda, Node> pandasInNetwork = new Dictionary<IPanda, Node>();

        public void AddPanda(IPanda panda)
        {
            // TODO : check if panda exceptions works legit
            try
            {
                if (!this.pandasInNetwork.ContainsKey(panda))
                {
                    this.pandasInNetwork.Add(panda, new Node(panda));
                }
                else
                {
                    throw new PandasAlreadyFriendsException();
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

        public void MakeFriends(IPanda panda1, IPanda panda2)
        {
            bool notFriends = true;
            Node friendNode1;
            Node friendNode2;
            if (!(this.pandasInNetwork.ContainsKey(panda1)))
            {
                friendNode1 = new Node(panda1);
                this.pandasInNetwork.Add(panda1, friendNode1);
                notFriends = !notFriends;
            }
            else
            {
                friendNode1 = this.pandasInNetwork[panda1];
            }
            if (!(this.pandasInNetwork.ContainsKey(panda2)))
            {
                friendNode2 = new Node(panda2);
                this.pandasInNetwork.Add(panda2, friendNode2);
                notFriends = !notFriends;
            }
            else
            {
                friendNode2 = this.pandasInNetwork[panda2];

            }

            if (notFriends)
            {
                friendNode1.PandasFriends.Add(friendNode2);
                friendNode2.PandasFriends.Add(friendNode1);
            }

            throw new PandasAlreadyFriendsException();
        }
        
        public bool AreFriend(IPanda panda1, IPanda panda2)
        {
            /*bool notFriends = true;
             Node friendNode1, friendNode2;
             if (PandasInNetwork.ContainsKey(panda1)&& PandasInNetwork.ContainsValue(friendNode1)))
             {
             nopenopenope TODOOO

             }*/
            return true;
        }

        // TODO : class node set to private/internal ?
        public class Node
        {
            private IPanda panda;

            private HashSet<Node> pandasFriends;

            public Node(IPanda panda)
            {
                this.panda = panda;
                this.pandasFriends = new HashSet<Node>();
            }

            public IPanda Panda1
            {
                get
                {
                    return this.panda;
                }

                set
                {
                    this.panda = value;
                }
            }

            internal HashSet<Node> PandasFriends
            {
                get
                {
                    return this.pandasFriends;
                }

                set
                {
                    this.pandasFriends = value;
                }
            }
        }
    }
}

