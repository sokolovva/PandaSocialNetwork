

namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SocialNetwork
    {
        /// <summary>
        /// obj=Panda
        /// </summary>
        Dictionary<object, Node> PandasInNetwork=new Dictionary<object, Node> ();

        

        public void AddPanda(object panda)
        {
            try
            {
                if (PandasInNetwork.ContainsKey(panda) == false)
                {
                    PandasInNetwork.Add(panda, new Node(panda));
                }

            }
            // TODO:    PandasAlreadyFriendsException
            catch (ArgumentException)
            {
                Console.WriteLine("Panda already has been added");
            }
           
        }

        public bool HasPanda(object panda)
        {
            if (PandasInNetwork.ContainsKey(panda))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void MakeFriends(object panda1, object panda2)
        {
            bool notFriends = true;
            Node friendNode1, friendNode2;
            if (!(PandasInNetwork.ContainsKey(panda1)))
            {
                friendNode1 = new Node(panda1);
                PandasInNetwork.Add(panda1, friendNode1);
                notFriends = !notFriends;
            }
            else
            {
                friendNode1 = PandasInNetwork[panda1];
            }
            if (!(PandasInNetwork.ContainsKey(panda2)))
            {
                friendNode2 = new Node(panda2);
                PandasInNetwork.Add(panda2, friendNode2);
                notFriends = !notFriends;
            }
            else
            {
               friendNode2 = PandasInNetwork[panda2];
                
            }
           
            if (notFriends)
            {
                friendNode1.PandasFriends1.Add(friendNode2);
                friendNode2.PandasFriends1.Add(friendNode1);
            }
            else throw new ArgumentException("Already friends!");


        }


        public bool AreFriend(object panda1, object panda2)
        {
           /*bool notFriends = true;
            Node friendNode1, friendNode2;
            if (PandasInNetwork.ContainsKey(panda1)&& PandasInNetwork.ContainsValue(friendNode1)))
            {
            nopenopenope TODOOO

            }*/

            return true;

        }




        public class Node
        {
            private object panda;
            private HashSet<Node> PandasFriends;

            public object Panda1
            {
                get
                {
                    return panda;
                }

                set
                {
                    panda = value;
                }
            }

            internal HashSet<Node> PandasFriends1
            {
                get
                {
                    return PandasFriends;
                }

                set
                {
                    PandasFriends = value;
                }
            }
            public Node(object panda)
            {
                this.panda = panda;
                PandasFriends = new HashSet<Node>();
            }

        }
      
        }
    }

