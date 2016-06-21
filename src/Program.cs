using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DynamicX86
{
    // generate native method that returns 42
    internal class Program
    {
        const uint PageExecuteReadwrite = 0x40;
        const uint MemCommit = 0x1000;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        private delegate int IntReturner();

        internal static void Main(string[] args)
        {
            var bodyBuilder = new List<byte>();
            bodyBuilder.Add(0xb8);
            bodyBuilder.AddRange(BitConverter.GetBytes(42));
            bodyBuilder.Add(0xc3);
            var body = bodyBuilder.ToArray();
            var buf = VirtualAlloc(IntPtr.Zero, (uint)body.Length, MemCommit, PageExecuteReadwrite);
            Marshal.Copy(body, 0, buf, body.Length);

            var ptr = (IntReturner)Marshal.GetDelegateForFunctionPointer(buf, typeof(IntReturner));
            Console.WriteLine(ptr());
            Console.ReadKey();
        }
    }
}
