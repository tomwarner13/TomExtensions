using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TomExtensions.Exceptions
{
  [Serializable()]
  public class ThisShouldNeverHappenException : System.Exception
  {
    public ThisShouldNeverHappenException() : base() { }

    public ThisShouldNeverHappenException(string message) : base(message) { }

    public ThisShouldNeverHappenException(string message, System.Exception inner) : base(message, inner) { }

    protected ThisShouldNeverHappenException(SerializationInfo info, StreamingContext context) { }
  }
}
