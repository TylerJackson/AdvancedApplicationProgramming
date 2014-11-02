/* Name: Program 5 part 1
 * Author: Tyler Jackson
 * Date: 10/5/14
 * Description: This is problem 1 in program 5.  This problem contains the correct implementation of the IDisposable
 *              interface and how to use it with unmanaged and managed resources.
 *                 i.e. always dispose of unmanaged resources, and dispose of managed resources when Dispose is called by
 *                      the user.
 *              Things to look out for were supressing finalize if I am calling dispose so that it doesn't call the dispose
 *              twice.
 * 
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    class Program
    {
        static void Main(string[] args)
         {
             DoStuff();
             GC.Collect();
             Console.ReadLine();
         }
         private static void DoStuff()
         {
             using (var instance1 = new MyClass())
             {
                instance1.PrintMessage();
             }
             var instance2 = new MyClass();
             instance2.PrintMessage();
         }    }
    class UnManagedResourceUtility
    {
         public static IntPtr CreateUnManagedResource()
         {
            return new IntPtr();
         }
         public static void CleanupUnManagedResource(IntPtr intPtr)
         {
            Console.WriteLine("Cleaning up unmanaged resource");
         }
    }
    class MyClass : IDisposable
    {
        private FileStream fileStream;
        private IntPtr intPtr;
        public MyClass()
        {
            try
            {
                fileStream = new FileStream(@"C:\temp\temp.txt", FileMode.OpenOrCreate);
                intPtr = UnManagedResourceUtility.CreateUnManagedResource();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Make sure you have a directory named 'temp' on your c drive");
            }
        }
        public void PrintMessage()
        {
            Console.WriteLine("Inside MyClass Print Message");
        }

        //dispose calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~MyClass()
        {
            //finalizer calls Dispose(false)
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                //free managed resources
                if(fileStream != null)
                {
                    fileStream.Dispose();
                    fileStream = null;
                }
            }
            //free native resources if there are any
            if(intPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(intPtr);
                intPtr = IntPtr.Zero;
            }
        }
    }
}
