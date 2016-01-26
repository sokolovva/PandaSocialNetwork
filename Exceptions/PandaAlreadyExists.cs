using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class PandasAlreadyExists : Exception
    {
        public PandasAlreadyExists() : base("Panda already exists!") { }
        public PandasAlreadyExists(string message) : base(message) { }
        public PandasAlreadyExists(string message, Exception inner) : base(message, inner) { }
        protected PandasAlreadyExists(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
