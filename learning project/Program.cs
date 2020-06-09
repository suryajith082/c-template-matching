using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace learning_project
{
    class Program
    {
        [DllImport("C:\\Users\\Acer PC\\source\\repos\\templateMatching\\x64\\Debug\\templateMatching.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int res([MarshalAs(UnmanagedType.LPStr)] String a, [MarshalAs(UnmanagedType.LPStr)]String b);
        public static void Main()
        {
            int ret = res("C:\\Users\\Acer PC\\Desktop\\New folder\\search.jpg", "C:\\Users\\Acer PC\\Desktop\\New folder\\google.jpg");
            Console.WriteLine("Return Value: " + ret);
            Console.ReadLine();
        }
    }
}
