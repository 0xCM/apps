//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct BasicMemoryInfo
    {
        public const string TableId = "memory.basic";

        public MemoryAddress BaseAddress;

        public MemoryAddress AllocationBase;

        public ByteSize RegionSize;

        public ByteSize StackSize;

        public PageProtection AllocProtect;

        public PageProtection Protection;

        public MemState State;

        public MemType Type;
    }
}