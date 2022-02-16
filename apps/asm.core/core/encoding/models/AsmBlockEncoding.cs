//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmBlockEncoding
    {
        public readonly Identifier BlockName;

        public readonly MemoryAddress BlockAddress;

        public readonly Index<AsmEncoding> Encoded;

        [MethodImpl(Inline)]
        public AsmBlockEncoding(Identifier name, MemoryAddress address, AsmEncoding[] src)
        {
            BlockName = name;
            BlockAddress = address;
            Encoded = src;
        }
    }
}