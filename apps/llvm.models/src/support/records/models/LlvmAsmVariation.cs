//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmVariation
    {
        public const string TableId = "llvm.asm.variation";

        public const byte FieldCount = 4;

        public uint Key;

        public AsciBlock32 Name;

        public AsmMnemonic Mnemonic;

        public AsciBlock16 Code;

        [MethodImpl(Inline)]
        public LlvmAsmVariation(uint id, in AsciBlock32 name, in AsmMnemonic monic, in AsciBlock16 code)
        {
            Key = id;
            Name = name;
            Mnemonic = monic;
            Code = code;
        }
    }
}