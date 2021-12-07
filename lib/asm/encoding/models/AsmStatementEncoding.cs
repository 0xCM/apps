//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Bindes an expression with its encoding
    /// </summary>
    [Record(TableId)]
    public struct AsmStatementEncoding : IEquatable<AsmStatementEncoding>, IComparable<AsmStatementEncoding>
    {
        public const string TableId = "asm.statement.encoding";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint DocSeq;

        public AsmExpr Asm;

        public LineNumber Line;

        public Address32 Offset;

        public AsmHexCode Encoding;

        [MethodImpl(Inline)]
        public AsmStatementEncoding(uint seq, uint docseq, AsmExpr asm, LineNumber line, Address32 offset, AsmHexCode code)
        {
            Seq = seq;
            DocSeq = docseq;
            Asm = asm;
            Line = line;
            Offset = offset;
            Encoding = code;
        }

        public bool Equals(AsmStatementEncoding src)
            => Asm.Equals(src.Asm) && Encoding.Equals(src.Encoding);

        public int CompareTo(AsmStatementEncoding src)
            => Encoding.CompareTo(src.Encoding);

        public override bool Equals(object src)
            => src is AsmStatementEncoding x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Asm.GetHashCode(), Encoding.GetHashCode());

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,64,32,32,1};
    }
}