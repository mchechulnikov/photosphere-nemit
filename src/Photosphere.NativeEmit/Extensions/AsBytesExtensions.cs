using System;

namespace Photosphere.NativeEmit.Extensions
{
    internal static class AsBytesExtensions
    {
        public static byte[] AsBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}