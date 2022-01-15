//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmDocCorrelation : IAsmEncoding
    {
        public const string TableId = "asm.correlation";

        public const byte FieldCount = 10;

        public uint Seq;

        public uint DocSeq;

        public @string SrcId;

        public Address32 IP;

        public AsmId AsmId;

        public AsmExpr Asm;

        public byte Size;

        public AsmHexCode HexCode;

        public @string Syntax;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Encoding
            => HexCode;

        MemoryAddress IAsmEncoding.Offset
            => IP;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,12,22,124,4,42,84,1};
    }
}
