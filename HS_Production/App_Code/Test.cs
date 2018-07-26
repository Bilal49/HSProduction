using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract  class Test
    {
        public abstract string GetUserName();

        //A Non abstract method
        public int AddTwoNumbers(int Num1, int Num2)
        {
            return Num1 + Num2;
        }
        public virtual void StepA()
        {
            Console.Out.WriteLine("Zing");
        }
    }

