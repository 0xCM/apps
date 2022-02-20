//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;


    partial class CheckCmdProvider
    {
        public static ReadOnlySpan<byte> mul_32u_32u_32u => new byte[11]{0x0f,0x1f,0x44,0x00,0x00,0x8b,0xc1,0x0f,0xaf,0xc2,0xc3};

        public static ReadOnlySpan<byte> inc_8u_8u => new byte[14]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0xff,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> vadd_128x8u => new byte[22]{0xc5,0xf8,0x77,0x66,0x90,0xc5,0xf9,0x10,0x02,0xc4,0xc1,0x79,0xfc,0x00,0xc5,0xf9,0x11,0x01,0x48,0x8b,0xc1,0xc3};

        static unsafe string fx1()
        {
            var f = MemFx.binop<uint>(mul_32u_32u_32u);
            var a = 5u;
            var b = 10u;
            var expect = a*b;
            var c = f(a,b);
            return string.Format("{0}*{1}={2}", a, b, c);
        }

        static unsafe string fx2()
        {
            var f = MemFx.unaryop<byte>(inc_8u_8u);
            var expect = (byte)6;
            var a = (byte)5;
            var b = Require.equal(f(a), expect);
            return string.Format("++{0}={1}", a, b);
        }

        public unsafe string fx3()
        {
            var f = MemFx.binop_ptr<byte>(vadd_128x8u);
            var a = vmask.veven<byte>(w128, n2, n1);
            var b = vmask.veven<byte>(w128, n2, n2);
            var c = MemFx.invoke(f, a, b);

            return string.Format("<{0}> + <{1}> = <{2}>", a.FormatHex(), b.FormatHex(), c.FormatHex());
        }

        [CmdOp("check/fx/pointers")]
        unsafe Outcome CheckFxPtr(CmdArgs args)
        {
            Write(fx1());
            Write(fx2());
            Write(fx3());
            return true;
        }
    }
}