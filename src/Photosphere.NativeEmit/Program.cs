using System;
using System.Runtime.InteropServices;
using Photosphere.NativeEmit.External;
using Photosphere.NativeEmit.x86;
using Photosphere.NativeEmit.x86.Enums;

namespace Photosphere.NativeEmit
{
    // generate native method that returns 42
    internal class Program
    {
        private const uint PageExecuteReadwrite = 0x40;
        private const uint MemCommit = 0x1000;

        private delegate int IntReturner();

        public static int Get42()
        {
            var body = new Emitter()
                .Mov(Register.Eax, 42)
                .Ret()
                .ToArray();
            var buf = Kernel32.VirtualAlloc(IntPtr.Zero, (uint)body.Length, MemCommit, PageExecuteReadwrite);
            Marshal.Copy(body, 0, buf, body.Length);

            var ptr = (IntReturner) Marshal.GetDelegateForFunctionPointer(buf, typeof(IntReturner));
            return ptr();
        }
    }
}
