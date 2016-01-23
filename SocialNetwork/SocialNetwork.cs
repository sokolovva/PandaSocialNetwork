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

        // TODO : check logic - add pandas as friends rather Nodes?
        public void MakeFriends(IPanda panda1, IPanda panda2)
        {
            Node friendNode1;
            Node friendNode2;
            if (!(this.pandasInNetwork.ContainsKey(panda1)))
            {
                friendNode1 = new Node(panda1);
                this.pandasInNetwork.Add(panda1, friendNode1);
            }
            else
            {
                friendNode1 = this.pandasInNetwork[panda1];
            }

            if (!(this.pandasInNetwork.ContainsKey(panda2)))
            {
                friendNode2 = new Node(panda2);
                this.pandasInNetwork.Add(panda2, friendNode2);
            }
            else
            {
                friendNode2 = this.pandasInNetwork[panda2];

            }
            // TODO : fix check for already friends
            if (true)
            {
                friendNode1.PandasFriends.Add(friendNode2);
                friendNode2.PandasFriends.Add(friendNode1);
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

        // TODO : class node set to private/internal ?
        public class Node
        {
            private IPanda panda;

            // TODO : HashSet of pandas instead of Nodes?
            private HashSet<Node> pandasFriends;

            public Node(IPanda panda)
            {
                this.panda = panda;
                this.pandasFriends = new HashSet<Node>();
            }

            public IPanda Panda
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

            // TODO : same as field - HashSet<Node> or HashSet<Panda> ?
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

