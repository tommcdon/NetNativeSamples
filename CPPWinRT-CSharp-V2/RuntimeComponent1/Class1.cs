using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeComponent1
{
    public sealed class Class1
    {
        int CallNumber;

        public string GetMyString()
        {
            return $"This is call #: {++CallNumber}";
        }
    }
}
