//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmInstruction
    {
        const string TableId = "asm.nasm.instructions";

        public const byte FieldCount = 5;

        [Render(12)]
        public uint Sequence;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(64)]
        public CharBlock64 Operands;

        [Render(64)]
        public CharBlock64 Encoding;

        [Render(32)]
        public CharBlock32 Flags;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,16,64,64,32};
    }
}