/* Name:        Program 4 part4
 * Author:      Tyler Jackson
 * Date:        9/24/14
 * Description: This part of the hw assignment will utliize a Ninja class that will be equipped with 5 shruiken.  It will have 2
 *              actions, one attached to the event when a shuriken is thrown in the Attack() method and another when the Ninja has
 *              no shuriken left.  Then in main I will instantiate an instance of the Ninja class and call attack 6 times.  I will
 *              also attach a handler to each event that will write to the console when they are called.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4Part4
{
    class Program
    {
        static void Main(string[] args)
        {
            //create my Ninja instance
            var nin = new Ninja();

            //attach the 2 handlers to the actions created in my Ninja class
            nin.WeaponUsed += WeaponUsedHandler;
            nin.OutOfWeapons += OutOfWeaponsHandler;

            //call Attack 6 times as specified
            nin.Attack();
            nin.Attack();
            nin.Attack();
            nin.Attack();
            nin.Attack();
            nin.Attack();
            Console.ReadLine();
        }

        //write to the console when the action OutOfWeapons is raised
        private static void OutOfWeaponsHandler()
        {
            Console.WriteLine("The ninja is out of shuriken");
        }

        //write to the console when the action WeaponUsed is raised
        private static void WeaponUsedHandler(int obj)
        {
            Console.WriteLine("Shuriken thrown");
        }
    }
}
