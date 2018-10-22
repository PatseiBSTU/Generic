using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------------------------------");
           SafeCollection<int> safeInt = new SafeCollection<int>(10);
            safeInt.Add(67);
            safeInt.Add(200);
            Console.WriteLine($"Generic collection with int type:");
            Console.WriteLine($"Length: {safeInt.Count}");
            foreach (var item in safeInt)
            {
                Console.Write($"{item}  ");
            }
            try
            {
                Console.WriteLine($"\n---------------------------------------");
                Console.WriteLine($"\nContains '200':  {safeInt.Contains(200)}");
                Console.WriteLine($"Contains '100':  {safeInt.Contains(100)}");

                Console.WriteLine("---------------------------------------");
                safeInt.Insert(0, 123);
              
                Console.WriteLine($"Remove 100 {safeInt.Remove(100)}");
                safeInt.RemoveAt(0);
                foreach (var item in safeInt)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine("\n---------------------------------------");

                Console.WriteLine($"Generic collection with user's class {typeof(Text)}");
                Text[] a = new Text[4];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = new Text($"Text{i}");
                }
                Console.WriteLine("---------------------------------------");
                var textCollection = new SafeCollection<Text>(4);
                textCollection.Add(a[0]);
                textCollection.Add(a[1]);
                textCollection.Add(a[2]);
                textCollection.Add(a[3]);
                textCollection.ToFile();
          
                Console.WriteLine($"Test LINQ:");
                SafeCollection<int>[] arrayCollections = new SafeCollection<int>[]
                        { new  SafeCollection<int>(8) { 3, 4, 44, 5, 66, 77, 8, 90 },
                          new  SafeCollection<int>(7) { 1, 77, 2, 22, 222, 2222, 23 },
                          new  SafeCollection<int>(4) { 87, 5, 54, 23 }
                        };

               
                int min = arrayCollections.Min(coll => coll.Count);
                var Min = from coll in arrayCollections
                          where coll.Count == min
                          select coll;
                foreach (var item in Min)
                {
                    Console.WriteLine("Minimal collection");
                    foreach (var item1 in item)
                    {
                        Console.Write($"{item1}  ");
                    }
                }
                Console.WriteLine("\n---------------------------------------");
                int max = arrayCollections.Max(coll => coll.Count);
                var Max = from coll in arrayCollections
                          where coll.Count == max
                          select coll;
                foreach (var item in Max)
                {
                    Console.WriteLine("Maximal collection");
                    foreach (var item1 in item)
                    {
                        Console.Write($"{item1}  ");
                    }
                }
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"LINQ with List<string>: ");
                 List<string> ListString = new List<string>(6)
                                         {
                                            "123", "Hello world", "1",
                                            "monday", "2019", "  "
                                         };
                foreach (var item in ListString)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------------------------------------");
                ListString.Sort();
                Console.WriteLine("After  sort");
                foreach (var item in ListString)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\nAfter lower sort in linq");
                var result= ListString.ToArray()
                                           .OrderByDescending(s => s);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("---------------------------------------");
                var count = ListString.Count(n => n.Length <= 3);
                Console.WriteLine($"Count string with length <= 3 :  {count}");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Output string with 'w' :");
                var stringWithValue = from s in ListString where s.Contains("w") == true select s;
                foreach (var item in stringWithValue)
                {
                    Console.WriteLine(item);
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\nIndexOutOfRangeException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nExeption:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Block finally");
            }

        }

    }
}

