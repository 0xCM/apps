//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    public class AsmBlockEncoding
    {
        public StringRef BlockName {get;}

        public MemoryAddress BlockAddress {get;}

        ConstLookup<MemoryAddress,AsmCode> CodeLookup;

        public AsmBlockEncoding(StringRef block, MemoryAddress address, AsmCode[] code)
        {
            BlockName = block;
            BlockAddress = address;
            CodeLookup = code.Map(c => (c.Offset, c)).ToDictionary();
        }

        public AsmCode this[MemoryAddress offset]
        {
            [MethodImpl(Inline)]
            get => CodeLookup[offset];
        }

        public ReadOnlySpan<AsmCode> Code
        {
            [MethodImpl(Inline)]
            get => CodeLookup.Values;
        }

        public ReadOnlySpan<MemoryAddress> Offsets
        {
            [MethodImpl(Inline)]
            get => CodeLookup.Keys;
        }

        public uint StatementCount
        {
            [MethodImpl(Inline)]
            get => CodeLookup.EntryCount;
        }
    }
}