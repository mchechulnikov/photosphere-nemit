using System;
using Photosphere.NativeEmit.x86.Enums;

namespace Photosphere.NativeEmit.Extensions
{
    internal static class AsBytesExtensions
    {
        public static byte[] AsBytes(this OpCode opCode)
        {
            return ((int) opCode).AsBytes();
        }

        public static byte[] AsBytes(this Register register)
        {
            return ((int) register).AsBytes();
        }

        public static byte[] AsBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}