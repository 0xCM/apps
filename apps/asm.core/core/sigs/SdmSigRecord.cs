//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct SdmSigRecord
    {
        public const byte FieldCount = 3;

        public const string TableId = "sdm.forms";

        public uint Seq;

        public Identifier Name;

        public AsmSig Sig;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,36,36};
    }
}