//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Bindes an expression with its encoding
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmStatementEncoding : IEquatable<AsmStatementEncoding>, IComparable<AsmStatementEncoding>, IAsmStatementEncoding
    {
        public const string TableId = "asm.statement.encoding";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint DocSeq;

        public LineNumber Line;

        public Address32 Offset;

        public AsmExpr Asm;

        public AsmHexCode Encoding;


        public bool Equals(AsmStatementEncoding src)
            => Asm.Equals(src.Asm) && Encoding.Equals(src.Encoding);

        public int CompareTo(AsmStatementEncoding src)
            => Encoding.CompareTo(src.Encoding);

        public override bool Equals(object src)
            => src is AsmStatementEncoding x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Asm.GetHashCode(), Encoding.GetHashCode());

        uint ISequential.Seq
            => Seq;
        AsmExpr IAsmStatementEncoding.Asm
            => Asm;

        AsmHexCode IAsmStatementEncoding.Encoding
            => Encoding;

        MemoryAddress IAsmStatementEncoding.Offset
            => Offset;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,12,12,64,1};

    }
}