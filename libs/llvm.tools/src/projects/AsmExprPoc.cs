//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using N = AsmExprPoc.AsmNames;

    [ApiHost]
    public readonly partial struct AsmExprPoc
    {
        public readonly struct AsmNames
        {
            public const string bsr = nameof(bsr);

            public const string bsf = nameof(bsf);

            public const string mov = nameof(mov);
        }

        const string RP1 = "{0} {1}";

        const string RP2 = "{0} {1}, {2}";

        [Op]
        public static AsmExpr bsf(r16 a, r16 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsf(r16 a, m16 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsf(r32 a, r32 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsf(r32 a, m32 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsf(r64 a, r64 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsf(r64 a, m64 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmExpr bsr(r16 a, r16 b)
            => string.Format(RP2, N.bsr, a,b);

        [Op]
        public static AsmExpr bsr(r16 a, m16 b)
            => string.Format(RP2, N.bsr, a,b);

        [Op]
        public static AsmExpr bsr(r32 a, r32 b)
            => string.Format(RP2, N.bsr, a,b);

        [Op]
        public static AsmExpr bsr(r32 a, m32 b)
            => string.Format(RP2, N.bsr, a,b);

        [Op]
        public static AsmExpr bsr(r64 a, r64 b)
            => string.Format(RP2, N.bsr, a,b);

        [Op]
        public static AsmExpr bsr(r64 a, m64 b)
            => string.Format(RP2, N.bsr, a,b);

        /// <summary>
        /// (88 /r | REX + 88 /r)  | mov r8,r8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmExpr mov(r8 a, r8 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// (88 /r | REX + 88 /r) mov m8,r8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmExpr mov(m8 a, r8 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// 89 /r             | MOV r/m16,r16
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmExpr mov(r16 a, r16 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// 89 /r             | MOV r/m16,r16
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmExpr mov(m16 a, r16 b)
            => string.Format(RP2, N.mov, a, b);
    }
}