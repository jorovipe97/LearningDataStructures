using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(6);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            int f = list[1];
            Console.WriteLine(f);
            list.RemoveAt(1);
            f = list[1];
            Console.WriteLine(f);
            Console.WriteLine(list.Count);

            MyList<int> myList = new MyList<int>();
            myList.Add(7);
            myList.Add(8);
            myList.Add(9);
            myList.Add(10);
            Console.WriteLine("List's Array's Length: " + myList.arr.Length);
            myList.Add(11);
            Console.WriteLine("List's Array's Length: " + myList.arr.Length);

            Console.WriteLine("myList[1] = " + myList[1]);
            myList.RemoveAt(1);
            Console.WriteLine("List's Array's Length: " + myList.arr.Length);
            Console.WriteLine("myList[1] = " + myList[1]);
            myList.Remove(9);
            Console.WriteLine("myList[1] = " + myList[1]);

            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.Add(myList);
            int n = (int) arrayList[0];
            arrayList[0] = 8;

            MyList<int> bar = (MyList<int>) arrayList[1];

            // Waits for a pressed key
            Console.ReadKey();
        }
    }
}
