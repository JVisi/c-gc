using System;

namespace ConsoleApp_GC
{
    public class BaseClass {
        public static int counter=0;
        public BaseClass() {
            counter++;
        }
         ~BaseClass(){
            counter--;
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int prev = 0;
            while (true) {
                int counter = BaseClass.counter;
                if (counter >= prev)
                {

                    var c = new BaseClass();
                    Console.WriteLine(BaseClass.counter);
                }
                else {
                    Console.WriteLine("\n GC: "+counter);
                    break;
                }
                prev = counter;
            }
        }
    }
}
