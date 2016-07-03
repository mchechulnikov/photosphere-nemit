using System;
using System.Runtime.InteropServices;
using Photosphere.NativeEmit.External;
using Photosphere.NativeEmit.External.Enums;

namespace Photosphere.NativeEmit.x86
{
    public static class NativeMethodGenerator
    {
        public static NativeMethodRet32 Generate(NativeMethodBuilder methodBuilder)
        {
            var methodBytes = methodBuilder.ToArray();
            var buffer = Allocate(methodBuilder);
            Marshal.Copy(methodBytes, 0, buffer, methodBuilder.Size);
            return (NativeMethodRet32) Marshal.GetDelegateForFunctionPointer(buffer, typeof(NativeMethodRet32));
        }

        private static IntPtr Allocate(NativeMethodBuilder methodBuilder)
        {
            return Kernel32.VirtualAlloc(IntPtr.Zero, (uint) methodBuilder.Size, (uint) AllocationType.MemCommit, (uint) MemoryProtection.PageExecuteReadwrite);
        }
    }
}