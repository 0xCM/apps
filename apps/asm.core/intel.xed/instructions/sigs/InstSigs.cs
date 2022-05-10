//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public partial class InstSigs
        {

            static Index<SigToken> CalcSigTokens() => new SigToken[]{
                "agen",

                "base0",
                "base1",

                "imm8",
                "imm16",
                "imm32",
                "imm64",

                "index8",
                "index80",

                "m8",
                "m16",
                "m32",
                "m64",
                "m80",
                "m128",
                "m256",
                "m512",
                "m4068",

                "ptr48",

                "r8",
                "r16",
                "r32",
                "r64",
                "r80",
                "xmm",
                "ymm",
                "zmm",

                "relbr32",
                "relbr8",

                "scale",

                "seg0",
                "seg1",
            };

            public static void render(Pairings<InstPattern,InstSig> src, ITextEmitter dst)
            {
                const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
                dst.AppendLineFormat(RenderPattern, "Instruction", "Lock", "OpCode", "Vector");
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var pattern = ref src[i].Left;
                    ref readonly var vector = ref src[i].Right;
                    dst.AppendLineFormat(RenderPattern, classifier(pattern.InstClass), pattern.Lock, pattern.OpCode, vector);
                }
            }

            public static Pairings<InstPattern,InstSig> sigs(Index<InstPattern> src)
            {
                var dst = alloc<Paired<InstPattern,InstSig>>(src.Count);
                for(var i=0; i<src.Count; i++)
                    seek(dst,i) = (src[i],sig(src[i]));
                return dst;
            }

            public static InstSig sig(InstPattern src)
            {
                ref readonly var ops = ref src.OpDetails;
                var count = (byte)ops.Count;
                var dst = InstSig.init(count);
                for(var i=z8; i<count; i++)
                {
                    ref readonly var op = ref ops[i];
                    var ind = InstSigs.indicator(op.Name);
                    dst[i] = InstSig.op(op.Index, op.Name, ind, op.Kind, op.BitWidth);
                }
                return dst;
            }

            public static string format(in InstSig src)
            {
                var dst = text.buffer();
                if(src.N > 0)
                {
                    dst.Append(Chars.Lt);
                    for(var i=z8; i<src.N; i++)
                    {
                        if(i !=0)
                        {
                            dst.Append(Chars.Comma);
                            dst.Append(Chars.Space);
                        }

                        ref readonly var c = ref src[i];
                        dst.Append(c.Indicator.Format());
                        if(c.Bits != 0)
                        {
                            dst.AppendFormat(":w{0}", c.Bits);
                        }

                    }
                    dst.Append(Chars.Gt);
                }

                return dst.Emit();
            }

            [MethodImpl(Inline), Op]
            static OpIndicator i(string src)
                => new OpIndicator(src);

            static Index<OpNameKind,OpIndicator> _KindIndicators = new OpIndicator[]{
                i(""),
                i("r0"),
                i("r1"),
                i("r2"),
                i("r3"),
                i("r4"),
                i("r5"),
                i("r6"),
                i("r7"),
                i("r8"),
                i("r9"),
                i("m0"),
                i("m1"),
                i("imm0"),
                i("imm1"),
                i("imm2"),
                i("relbr"),
                i("base0"),
                i("base1"),
                i("seg0"),
                i("seg1"),
                i("agen"),
                i("ptr"),
                i("index"),
                i("scale"),
                i("disp"),
            };

            [MethodImpl(Inline), Op]
            public static OpIndicator indicator(OpNameKind src)
                => _KindIndicators[src];
        }
    }
}