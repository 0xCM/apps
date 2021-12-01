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
    public readonly struct AsmExprEncoding : IEquatable<AsmExprEncoding>, IComparable<AsmExprEncoding>
    {
        public AsmExpr Asm {get;}

        public LineNumber Line {get;}

        public AsmHexCode Encoding {get;}

        [MethodImpl(Inline)]
        public AsmExprEncoding(AsmExpr asm, LineNumber line, AsmHexCode code)
        {
            Asm = asm;
            Line = line;
            Encoding = code;
        }

        public bool Equals(AsmExprEncoding src)
            => Asm.Equals(src.Asm) && Encoding.Equals(src.Encoding);

        public int CompareTo(AsmExprEncoding src)
            => Encoding.CompareTo(src.Encoding);

        public override bool Equals(object src)
            => src is AsmExprEncoding x && Equals(x);

        public override int GetHashCode()
            => (int)alg.hash.combine(Asm.GetHashCode(), Encoding.GetHashCode());
    }
}