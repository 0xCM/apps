//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static EncodingPatternKind;
    using static EncodingPatternTokens;

    using D = EncodingPatternOffset;

    readonly struct EncodingPatterns
    {
        public static EncodingPatterns Default
            => new EncodingPatterns(0);

        readonly EncodingPatternKind[] _Kinds;

        public int PatternCount {get;}

        public ReadOnlySpan<EncodingPatternKind> Kinds
            => _Kinds;

        EncodingPatterns(int dummy)
        {
            _Kinds = new EncodingPatternKind[]
            {
                EncodingPatternKind.RET_SBB,
                RET_INTR,
                EncodingPatternKind.RET_ZED_SBB,
                RET_Zx3,
                EncodingPatternKind.INTRx2,
                EncodingPatternKind.JMP_RAX,
                Zx7,
            };

            PatternCount = _Kinds.Length;
        }

        public ReadOnlySpan<byte> Pattern(EncodingPatternKind code)
            => code switch{
                EncodingPatternKind.RET_SBB => RET_SBB,
                RET_INTR => RET_INT,
                EncodingPatternKind.RET_ZED_SBB => RET_ZED_SBB,
                RET_Zx3 => RET_Zx2,
                EncodingPatternKind.INTRx2 => INTRx2,
                EncodingPatternKind.JMP_RAX => JMP_RAX,
                Zx7 => Z7,
                _ => Empty
            };

        public EncodingPatternOffset MatchOffset(EncodingPatternKind code)
            => code switch{
                EncodingPatternKind.RET_SBB => D.RET_SBB,
                RET_INTR => D.RET_INT,
                EncodingPatternKind.RET_ZED_SBB => D.RET_ZED_SBB,
                RET_Zx3 => D.RET_Zx3,
                EncodingPatternKind.INTRx2 => D.RET_INTRx2,
                EncodingPatternKind.JMP_RAX => D.JMP_RAX,
                Zx7 => D.Z7,
                RET_Zx7 => D.RET_Zx7,
                EncodingPatternKind.CALL32_INTR => D.CALL32_INTR,
                _ => 0
            };

        [MethodImpl(Inline)]
        public bool IsSuccessPattern(EncodingPatternKind kind)
            => kind != 0;

        static ReadOnlySpan<byte> RET_SBB
            => new byte[]{RET_xC3, SBB_x19};

        static ReadOnlySpan<byte> RET_INT
            => new byte[]{RET_xC3, INTR_xCC};

        static ReadOnlySpan<byte> RET_ZED_SBB
            => new byte[]{RET_xC3, ZED, SBB_x19};

        static ReadOnlySpan<byte> RET_Zx2
            => new byte[]{RET_xC3, ZED,ZED};

        static ReadOnlySpan<byte> INTRx2
            => new byte[]{INTR_xCC, INTR_xCC};

        static ReadOnlySpan<byte> JMP_RAX
            => new byte[]{ZED,ZED, Jmp_x48,FF,E0};

        static ReadOnlySpan<byte> Z7
            => new byte[]{ZED,ZED,ZED,ZED,ZED,ZED,ZED};

        static ReadOnlySpan<byte> Empty
            => sys.empty<byte>();
    }
}