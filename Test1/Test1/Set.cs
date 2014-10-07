using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Set<T>:IEnumerable
    {
        List<T> container;
        public int Count
        {
            get
            {
                return container.Count;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return !container.Any();
            }
        }



        //default constructor
        public Set()
        {
            container = new List<T>();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return container.GetEnumerator();
        }
        public Set(IEnumerable<T> e)
        {
            container = new List<T>();
            foreach(T temp in e)
            {
                container.Add(temp);
            }
            container.Distinct().ToList();
        }
        public static Set<T> operator+ (Set<T> rhs, Set<T> lhs)
        {
            var tempList = rhs.container.Union(lhs.container);
            var tempSet = new Set<T>(tempList);
            return tempSet;
        }

        public virtual bool Add(T item)
        {
            if(this.container.Contains(item))
            {
                return false;
            }
            else
            {
                this.container.Add(item);
                return true;
            }
        }

        public virtual bool Remove(T item)
        {
            if (this.container.Contains(item))
            {
                this.container.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(T item)
        {
            if (this.container.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Set<T> Filter(Func<T,bool> filterFunction)
        {
            var tempSet = new Set<T>();
            foreach(T temp in this.container)
            {
                
                if(filterFunction(temp))
                {
                    tempSet.Add(temp);
                }
            }
            return tempSet;
        }

    }
}
