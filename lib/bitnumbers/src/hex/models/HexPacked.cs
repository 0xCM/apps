//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct HexPacked : IRecord<HexPacked>
    {
        public const string TableId = "hexpack";

        const string FormatPattern = "x{0:x}[{1:D5}:{2:D5}]=<{3}>";

        public uint Index;

        public MemoryAddress Address;

        public uint Size;

        public string Data;

        public string Format()
            => string.Format(FormatPattern, (ulong)Address, Index, Size, Data);
    }
}