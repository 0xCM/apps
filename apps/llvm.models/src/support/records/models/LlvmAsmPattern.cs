//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmPattern
    {
        public const string TableId = "llvm.asm.patterns";

        public const byte FieldCount = 3;

        public uint Id;

        public AsciBlock32 Name;

        public AsciBlock32 Mnemonic;

        public AsciBlock64 Format;
    }
}