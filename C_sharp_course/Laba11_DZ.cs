using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using BildingSystem;

namespace BildingSystem
{
    public struct S { int A; }

    public class Program
    {
        static void Main()
        {
            object[] s = new object[2];
            s[0] = new S();
            s[1] = s[0];
            Console.WriteLine(s[0] == s[1]);
        }
    }
}
