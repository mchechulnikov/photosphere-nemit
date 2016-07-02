namespace Photosphere.NativeEmit.External.Enums
{
    internal enum AllocationType : uint
    {
        MemCommit = 0x1000,
        MemReserve = 0x2000,
        MemReset = 0x8000,
        MemReserveUndo = 0x1000000,
        MemLargePages = 0x20000000,
        MemPhysical = 0x00400000,
        MemTopDown = 0x00100000,
        MemWriteWatch = 0x00200000
    }
}