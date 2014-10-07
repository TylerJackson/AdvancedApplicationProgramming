using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class SortedSet<T>:Set<T>,IEnumerable where T:IComparable
    {
        List<T> container;
        public SortedSet()
        {
            container = new List<T>();
        }
        public SortedSet(IEnumerable<T> e)
        {
            container = new List<T>();
            foreach(T temp in e)
            {
                container.Add(temp);
            }
            container = container.Distinct().ToList();
            container.Sort();
        }

        public static SortedSet<T> operator +(SortedSet<T> rhs, SortedSet<T> lhs)
        {
            var tempList = rhs.container.Union(lhs.container);
            var tempSet = new SortedSet<T>(tempList);
            return tempSet;
        }

        public override bool Add(T item)
        {
            if (this.container.Contains(item))
            {
                return false;
            }
            else
            {
                this.container.Add(item);
                this.container.Sort();
                return true;
            }
        }

        public override bool Remove(T item)
        {
            if (this.container.Contains(item))
            {
                this.container.Remove(item);
                this.container.Sort();
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return container.GetEnumerator();
        }



    }
}
