//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct SdmFormRecord
    {
        public const byte FieldCount = 4;

        public const string TableId = "sdm.forms";

        public uint Seq;

        public CharBlock36 Name;

        public AsmSig Sig;

        public AsmOpCode OpCode;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,36,36,36};
    }
}