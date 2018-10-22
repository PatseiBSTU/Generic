using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
   
        interface IFile
        {
            void ToFile();
            void DeleteFile();
        }

        class Text: IComparable<Text>, IFile
        {
            public Text()
            {
            }
        public Text(string text) => TextS = text;

        public string TextS { get; set; } = "";

            public override bool Equals(object obj)
            {
                Text temp = obj as Text;
                if (temp != null)
                {
                    return temp.TextS == this.TextS;
                }
                return false;
            }

            public int CompareTo(Text other)
            {
                if (this.TextS == other.TextS)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }

        public override int GetHashCode() => Math.Abs(base.GetHashCode());
        public override string ToString() => string.Format($"string: {TextS}");
            public void ToFile()
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"/Info.txt", true))
                    {
                        sw.WriteLine($"{TextS}");
                        sw.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void DeleteFile()
            {
                try
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"/Info.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }

