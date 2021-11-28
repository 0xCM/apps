//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmVariation
    {
        public const string TableId = "llvm.asm.variation";

        public uint Key;

        public AsciBlock32 Name;

        public AsciBlock16 Mnemonic;

        public AsciBlock16 Code;

        [MethodImpl(Inline)]
        public LlvmAsmVariation(uint id, in AsciBlock32 name, in AsciBlock16 monic, in AsciBlock16 code)
        {
            Key = id;
            Name = name;
            Mnemonic = monic;
            Code = code;
        }
    }
}
