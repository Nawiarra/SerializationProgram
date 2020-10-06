using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoAvailablePropertiesException
{
    public class NoAvailablePropertiesException : Exception
    {
        public NoAvailablePropertiesException()
            : base(String.Format("No available for serialization properties in class"))
        {

        }
    }
}
