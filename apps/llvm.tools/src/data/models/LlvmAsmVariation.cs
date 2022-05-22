//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmVariation
    {
        public const string TableId = "llvm.asm.variation";

        public const byte FieldCount = 4;

        [Render(8)]
        public uint Key;

        [Render(32)]
        public asci32 Name;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(1)]
        public AsmVariationCode Code;

        [MethodImpl(Inline)]
        public LlvmAsmVariation(uint id, in asci32 name, in AsmMnemonic monic, in AsmVariationCode code)
        {
            Key = id;
            Name = name;
            Mnemonic = monic;
            Code = code;
        }
    }
}