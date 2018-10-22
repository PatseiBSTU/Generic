using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
       class SafeCollection<T> : IList<T> where T : new()
        {
            public SafeCollection() : this(defaultSize)
            {

            }
            public SafeCollection(int length)
            {
                Count = length;
                safeArray = new T[this.length];
            }

            protected T[] safeArray;
            protected int length = defaultSize;
            protected const int defaultSize = 5;
            protected const int minimalSize = 2;
            public T this[int index]
        {
            get => safeArray[index];
            set
            {
                if (index < 0 && index > length)
                {
                    throw new IndexOutOfRangeException();
                }
                safeArray[index] = value;
            }
        }
        public int Count
        {
            get => length;
            protected set
            {
                length = value > minimalSize ? value : defaultSize;
            }
        }
        public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }
            public void Add(T item)
            {
                for (int i = 0; i < length; i++)
                {
                    if (Equals(safeArray[i], default(T)))
                    {
                        safeArray[i] = item;
                        return;
                    }
                }
            }
            public void Clear()
            {
                for (int i = 0; i < length; i++)
                {
                    safeArray[i] = default(T);
                }
            }
            public bool Contains(T item)
            {
                if (safeArray.Contains(item))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            public void CopyTo(T[] array, int arrayIndex)
            {
                if (arrayIndex >= Count || arrayIndex < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (array.Length > this.safeArray.Length || array.Length + arrayIndex <= Count)
                {
                    throw new Exception("User's array is too long");
                }

                if (array == null || array.Length == 1)
                {
                    throw new Exception("Wrong array");
                }

                for (int i = arrayIndex, j = 0; i < Count; j++, i++)
                {
                    safeArray[i] = array[j];
                }
            }
            public int IndexOf(T item)
            {
                for (int i = 0; i < length; i++)
                {
                    if (safeArray[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }
            public void Insert(int index, T item)
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                safeArray[index] = item;
            }
            public bool Remove(T item)
            {
                for (int i = 0; i < length; i++)
                {
                    if (safeArray[i].Equals(item))
                    {
                        safeArray[i] = default(T);
                        return true;
                    }
                }
                return false;
            }
        public void RemoveAt(int index) => safeArray[index] = default(T);
        public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < Count; i++)
                {
                    if (!safeArray[i].Equals(default(T)))
                    {
                        yield return safeArray[i];
                    }
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return safeArray.GetEnumerator();
            }
            public void ToFile()
            {
                if (safeArray[0] is IFile)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        IFile a = safeArray[i] as IFile;
                        a.ToFile();
                    }
                }
            }
            public void DeleteFile()
            {
                if (safeArray[0] is IFile)
                {
                    IFile objForDelete = safeArray[0] as IFile;
                    objForDelete.DeleteFile();
                }
            }
        }
    }

