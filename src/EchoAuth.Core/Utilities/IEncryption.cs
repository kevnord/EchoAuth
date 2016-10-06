using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoAuth.Core.Utilities
{
    public interface IEncryption
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}
