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
            var f = FxPtr.binop<uint>(mul_32u_32u_32u);
            var a = 5u;
            var b = 10u;
            var expect = a*b;
            var c = f(a,b);
            return string.Format("{0}*{1}={2}", a, b, c);
        }

        static unsafe string fx2()
        {
            var f = FxPtr.unaryop<byte>(inc_8u_8u);
            var expect = (byte)6;
            var a = (byte)5;
            var b = Require.equal(f(a), expect);
            return string.Format("++{0}={1}", a, b);
        }

        public unsafe string fx3()
        {
            var f = FxPtr.binop_ptr<byte>(vadd_128x8u);
            var a = vmask.veven<byte>(w128, n2, n1);
            var b = vmask.veven<byte>(w128, n2, n2);
            var c = FxPtr.invoke(f, a, b);

            return string.Format("<{0}> + <{1}> = <{2}>", a.FormatHex(), b.FormatHex(), c.FormatHex());
        }

        [CmdOp("check/fptr")]
        unsafe Outcome CheckFxPtr(CmdArgs args)
        {
            Write(fx1());
            Write(fx2());
            Write(fx3());


            return true;
        }

        [CmdOp("check/asm/tokens")]
        Outcome CheckAsmTokens(CmdArgs args)
        {
            AsmSigs.parse("adc r16, r16", out var sig);
            AsmOpCodes.parse("11 /r", out var oc1);
            AsmOpCodes.parse("13 /r", out var oc2);
            var count = min(oc1.TokenCount, oc2.TokenCount);
            var token = AsmOcToken.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref oc1[i];
                ref readonly var tb = ref oc2[i];
                if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                if(ta != tb)
                {
                    token = tb;
                    break;
                }
            }

            if(AsmOpCodes.diff(oc1,oc2, out token))
            {
                Write(token.Format());
            }


            return true;
        }

        [CmdOp("check/asm/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var details = Sdm.LoadImportedOpcodes();
            var count = details.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                AsmSigs.parse(detail.Sig, out var sig);

                buffer.Append(sig.Mnemonic.Format());
                if(sig.OpCount != 0)
                {
                    buffer.Append("<");
                    for(var j=0; j<sig.OpCount; j++)
                    {
                        if(j != 0)
                            buffer.Append(", ");

                        buffer.Append(AsmSigs.identify(sig[j]));
                    }
                    buffer.Append(">");
                }

                Write(buffer.Emit());
            }

            return true;
        }
    }
}