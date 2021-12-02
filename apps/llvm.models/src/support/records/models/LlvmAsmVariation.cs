//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmVariation
    {
        public const string TableId = "llvm.asm.variation";

        public const byte FieldCount = 4;

        public uint Key;

        public AsciBlock32 Name;

        public AsmMnemonic Mnemonic;

        public AsmVariationCode Code;

        [MethodImpl(Inline)]
        public LlvmAsmVariation(uint id, in AsciBlock32 name, in AsmMnemonic monic, in AsmVariationCode code)
        {
            Key = id;
            Name = name;
            Mnemonic = monic;
            Code = code;
        }
    }
}