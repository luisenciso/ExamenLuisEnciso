using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {


            //ChangeString chns = new ChangeString();
            //Console.WriteLine(chns.build("123 abcd*3"));
            //Console.WriteLine(chns.build("**Casa 52"));
            //Console.ReadKey();



            //OrderRange ordr = new OrderRange();
            //List<int>[] res1 = ordr.build(new int[] { 2, 1, 4, 5 });
            //List<int>[] res2 = ordr.build(new int[] { 4, 2, 9, 3, 6 });
            //List<int>[] res3 = ordr.build(new int[] { 58, 60, 55, 48, 57, 73 });
            //Console.ReadKey();

            MoneyParts mny = new MoneyParts();
            List<List<String>> resStr1 = mny.build("0.1");
            List<List<String>> resStr2 = mny.build("0.5");
            List<List<String>> resStr3 = mny.build("10.5");
            Console.ReadKey();

        }
    }
}
