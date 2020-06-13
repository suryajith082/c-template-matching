using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace learning_project
{
    class Program
    {
        [DllImport("C:\\WINDOWS\\System32\\user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MOVE= 0x0001;
        private const int MOUSEEVENTF_ABSOLUTE= 0x8000;

        [DllImport("C:\\WINDOWS\\System32\\user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetCursorPos(int X,  int Y);


        [DllImport("C:\\Users\\Acer PC\\source\\repos\\templateMatching\\x64\\Debug\\templateMatching.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void res([MarshalAs(UnmanagedType.LPStr)] String a, [MarshalAs(UnmanagedType.LPStr)]String b, int* x, int* y);
        public unsafe static void Main()
        {
            int x, y;
            Console.WriteLine("Starting the process...");
            Thread.Sleep(5000);

            //Creating a Rectangle object which will  
            //capture our Current Screen
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            //Creating a new Bitmap object
            Bitmap captureBitmap = new Bitmap(captureRectangle.Right- captureRectangle.Left, captureRectangle.Bottom- captureRectangle.Top, PixelFormat.Format32bppArgb);
            //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
            //Creating a New Graphics Object
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            //Copying Image from The Screen
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            //Saving the Image File

            captureBitmap.Save(@"C:\Users\Acer PC\Desktop\New folder\Capture.jpg", ImageFormat.Jpeg);

            res("C:\\Users\\Acer PC\\Desktop\\New folder\\Capture.jpg", "C:\\Users\\Acer PC\\Desktop\\New folder\\newgoogle.jpg",&x,&y);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.ReadLine();
            int xpos=x+10;
            int ypos=y+10;
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Console.ReadLine();
            Console.ReadLine();
            File.Delete("C:\\Users\\Acer PC\\Desktop\\New folder\\Capture.jpg");
            
        }
    }
}
