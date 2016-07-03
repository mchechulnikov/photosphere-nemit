using System.Collections.Generic;
using Photosphere.NativeEmit.Extensions;
using Photosphere.NativeEmit.x86.Enums;

namespace Photosphere.NativeEmit.x86
{
    public class NativeMethodBuilder
    {
        private readonly List<byte> _bytes = new List<byte>();

        public int Size => _bytes.Count;

        public NativeMethodBuilder Mov(Register register, int value)
        {
            Write(OpCode.Mov);
            Write(value);
            if (register != Register.Eax)
            {
                Write(register);
            }
            return this;
        }

        public NativeMethodBuilder Ret()
        {
            Write(OpCode.Ret);
            return this;
        }

        public byte[] ToArray()
        {
            return _bytes.ToArray();
        }

        private void Write(int value)
        {
            Write(value.AsBytes());
        }

        private void Write(OpCode opCode)
        {
            _bytes.Add((byte) opCode);
        }

        private void Write(Register register)
        {
            _bytes.Add((byte) register);
        }

        private void Write(IEnumerable<byte> bytes)
        {
            _bytes.AddRange(bytes);
        }
    }
}