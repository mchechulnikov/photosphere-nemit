namespace Photosphere.NativeEmit.External.Enums
{
    internal enum MemoryProtection : uint
    {
        PageExecute = 0x10,
        PageExecuteRead = 0x20,
        PageExecuteReadwrite = 0x40,
        PageExecuteWritecopy = 0x80,
        PageNoaccess = 0x01,
        PageReadonly = 0x02,
        PageReadwrite = 0x04,
        PageWritecopy = 0x08,
        PageTargetsInvalid = 0x40000000,
        PageTargetsNoUpdate = 0x40000000,
        PageGuard = 0x100,
        PageNocache = 0x200,
        PageWritecombine = 0x400
    }
}