using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class PandasMustBeDifferentException : Exception
    {
        public PandasMustBeDifferentException() : base("The two pandas must bediffenret!") {}
        public PandasMustBeDifferentException(string message) : base(message) { }
        public PandasMustBeDifferentException(string message, Exception inner) : base(message, inner) { }
        protected PandasMustBeDifferentException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
