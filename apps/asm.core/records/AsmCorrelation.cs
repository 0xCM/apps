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
    public struct AsmDocCorrelation : IAsmStatementEncoding
    {
        public const string TableId = "asm.correlation";

        public const byte FieldCount = 10;

        public uint Seq;

        public uint DocSeq;

        public @string SrcId;

        public Address32 IP;

        public text31 AsmId;

        public AsmExpr Asm;

        public byte Size;

        public AsmHexCode HexCode;

        public @string Syntax;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmStatementEncoding.Asm
            => Asm;

        AsmHexCode IAsmStatementEncoding.Encoding
            => HexCode;

        MemoryAddress IAsmStatementEncoding.Offset
            => IP;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,12,32,84,4,42,84,1};
    }
}
