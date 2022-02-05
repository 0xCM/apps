//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using K = Asm.AsmOcTokenKind;
    using P = Pow2x32;

    using static core;
    using static Asm.AsmChecks;

    partial class CheckCmdProvider
    {
        [Op]
        public static uint serialize(PointMapper<K,P> src, Span<ushort> dst)
        {
            var points = src.Points;
            var count = points.Length;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                ref var t0 = ref @as<byte>(seek(dst,i));
                ref var t1 = ref @as<Log2x32>(seek(t0,1));
                t0 = u8(point.Left);
                t1 = Pow2.log(point.Right);
            }

            return 0;
        }

        public static Index<ushort> serialize(PointMapper<K,P> src)
        {
            var dst = alloc<ushort>(src.PointCount);
            serialize(src,dst);
            return dst;
        }

        [CmdOp("check/asm/widths")]
        Outcome TestAsmWidths(CmdArgs args)
        {
            var result = bit.On;
            var pass = bit.Off;
            var test = default(AsmSizeCheck);
            var inputs = Symbols.index<NativeSizeCode>().Kinds;
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                test.Input = input;
                pass = check(ref test);
                result &= pass;
                Write(test, pass ? FlairKind.Status : FlairKind.Error);
            }

            BitWidth w8 = 8;
            BitWidth w16 = 16;
            BitWidth w32 = 32;
            BitWidth w64 = 64;

            var sz8 = Sizes.native(w8);
            var sz16 = Sizes.native(w16);
            var sz32 = Sizes.native(w32);
            var sz64 = Sizes.native(w64);
            Write(sz8);
            Write(sz16);
            Write(sz32);
            Write(sz64);

            return (result, result ? "Pass" : "Fail");
        }
    }
}