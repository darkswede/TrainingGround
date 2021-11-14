using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    public class HideOverride
    {
        public void Test()
        {
            var a = new A();
            var b = new B();

            a.Over();
            b.Over();

            a = new B();
            a.Over();
        }
    }

    public class A
    {
        public void Over() => Console.Write("A: Over()");
    }

    public class B : A
    {
        public new void Over() => Console.WriteLine("B: Over()");
    }
}
