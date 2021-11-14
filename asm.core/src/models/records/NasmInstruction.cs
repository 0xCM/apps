//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmInstruction : IRecord<NasmInstruction>
    {
        public const string TableId = "nasm.instructions";

        public const byte FieldCount = 5;

        public uint Sequence;

        public CharBlock16 Mnemonic;

        public CharBlock64 Operands;

        public CharBlock64 Encoding;

        public CharBlock32 Flags;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,16,64,64,32};
    }
}