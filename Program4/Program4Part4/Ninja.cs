/* Name: Ninja class
 * Author: Tyler Jackson
 * Date: 9/24/14
 * Description:  This is the Ninja object.  It has one property NumShuriken and 2 actions WeaponUsed
 *              which is raised when Attack is called if there are any shuriken to throw, and OutOfWeapons
 *              which is raised if Attack is called and there are not any shuriken left.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4Part4
{
    class Ninja
    {
        public int NumShuriken { get; set; }
        public Ninja()
        {
            NumShuriken = 5;
        }
        public void Attack()
        {
            this.NumShuriken--;
            if (this.NumShuriken >= 0)
            {
                WeaponUsed(NumShuriken);
            }
            else
            {
                OutOfWeapons();
            }
        }
        public event Action<int> WeaponUsed;
        public event Action OutOfWeapons;

    }
}
