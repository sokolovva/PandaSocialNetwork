namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PandasAlreadyFriendsException : Exception
    {
        public PandasAlreadyFriendsException() : base("Pandas are already friends!") { }
        public PandasAlreadyFriendsException(string message) : base(message) { }
        public PandasAlreadyFriendsException(string message, Exception inner) : base(message, inner) { }
        protected PandasAlreadyFriendsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
