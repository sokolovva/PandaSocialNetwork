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
        readonly Dictionary<IPanda, IList<int>> pandasInNetwork = new Dictionary<IPanda, IList<int>>();

        public void AddPanda(IPanda panda)
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

        public bool HasPanda(IPanda panda)
        {
            return this.pandasInNetwork.ContainsKey(panda);
        }

        public void MakeFriends(IPanda panda1, IPanda panda2)
        {
            if (panda1.Equals(panda2))
            {
                throw new PandasMustBeDifferentException();
            }

            if (!this.pandasInNetwork.ContainsKey(panda1))
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

        public bool AreFriends(IPanda panda1, IPanda panda2)
        {
            if (panda1.Equals(panda2))
            {
                throw new PandasMustBeDifferentException();
            }

            return this.pandasInNetwork[panda1].Contains(panda2.GetHashCode());
        }

        public IEnumerable<IPanda> FirendsOf(IPanda panda)
        {
            var neighbours = this.pandasInNetwork.Select(x => x.Key).Where(y => this.pandasInNetwork[panda].Contains(y.GetHashCode()));
            return neighbours;
        }

        public IEnumerable<IPanda> FriendsOf(IPanda panda)
        {
            var friends = from pandas in this.pandasInNetwork.Keys
                          join hash in this.pandasInNetwork[panda]
                          on pandas.GetHashCode() equals hash
                          select pandas;
            return friends;
        }

        public int ConnectionLevel(IPanda panda1, IPanda panda2)
        {
            if (panda1.Equals(panda2))
            {
                throw new PandasMustBeDifferentException();
            }

            int counter = 0;
            var queue = new Queue<IPanda>();
            List<IPanda> visited = new List<IPanda>();

            visited.Add(panda1);
            queue.Enqueue(panda1);
            while (queue.Count > 0)
            {
                IPanda currPanda = queue.Dequeue();
                if (currPanda.Equals(panda2))
                {
                    Console.WriteLine(counter);
                    return counter;
                }

                foreach (int hash in this.pandasInNetwork[currPanda])
                {
                    var neighbours = this.pandasInNetwork.Select(x => x.Key).Where(y => y.GetHashCode() == hash).ToList();
                    foreach (IPanda neighbour in neighbours.Where(neighbour => !visited.Contains(neighbour)))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }

                counter++;
            }

            return -1;
        }
    }
}