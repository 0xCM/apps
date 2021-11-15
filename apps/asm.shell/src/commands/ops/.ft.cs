//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static TmpTables;

    using C = AsmPrefixCodes.RexPrefixCode;

    public readonly struct TmpTables
    {
        const byte PointCount = 5;

        public static ReadOnlySpan<C> Source
            => new C[PointCount]{C.Base, C.B, C.X, C.R, C.W};

        public static ReadOnlySpan<AsciCode> Target
            => new AsciCode[PointCount]{AsciCode.Bang, AsciCode.B, AsciCode.X, AsciCode.R, AsciCode.W};
    }

    partial class AsmCmdService
    {
        [CmdOp(".ft")]
        unsafe Outcome FT(CmdArgs args)
        {
            var src = recover<C,byte>(Source);
            ref var f = ref PointFunctions.fx<AsciCode>(n8, src, Target, out _);

            byte x = 0;

            x = skip(src,0);
            Write(f.Map(x));

            x = skip(src,1);
            Write(f.Map(x));

            x = skip(src,2);
            Write(f.Map(x));

            x = skip(src,3);
            Write(f.Map(x));

            x = skip(src,4);
            Write(f.Map(x));

            return true;
        }
    }
}