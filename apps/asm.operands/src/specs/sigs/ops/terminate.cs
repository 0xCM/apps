//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using K = AsmSigOpKind;

    using static AsmSigTokens;

    partial class AsmSigs
    {
        public static ReadOnlySpan<AsmSigOpKind> opkinds()
            => Datasets.Kinds;

        public static Index<AsmSig> terminate(in AsmSig src)
        {
            var sigs = list<AsmSig>();
            for(var i=z8; i<src.OpCount; i++)
            {
                var op = src.Operands[i];
                var terms = terminate(op);
                var opcount = terms.Count;

                var dst = alloc<AsmSig>(terms.Count);
                for(var m = 0; m<dst.Length; m++)
                {
                    var ops = alloc<AsmSigOp>(opcount);
                    ref var sig = ref seek(dst,m);
                    for(byte j=0; j<opcount; j++)
                    {
                        if(j == i)
                            sig.With(j, terms[i]);
                        else
                            sig.With(j, src[j]);
                    }
                }

                sigs.AddRange(dst);

            }
            return sigs.ToArray();
        }

        public static AsmSigOp operand<K>(K src)
            where K : unmanaged
                => new AsmSigOp(Datasets.Kind(typeof(K)), u8(src));

        public static Index<AsmSigOp> decompose(AsmSigOpKind kind, byte value)
        {
            var dst = list<AsmSigOp>();
            switch(kind)
            {
                case K.GpRm:
                {
                    var typedvalue = (GpRmToken)value;
                    switch(typedvalue)
                    {
                        case GpRmToken.rm8:
                            dst.Add(new AsmSigOp(K.GpReg, (byte)(GpRegToken.r8)));
                            dst.Add(new AsmSigOp(K.GpReg, (byte)(MemToken.m8)));
                        break;
                    }
                }
                break;
                default:
                    dst.Add(new AsmSigOp(kind, value));
                break;
            }

            return dst.ToArray();

        }

        public static Index<AsmSigOp> terminate(in AsmSigOp src)
        {
            var dst = list<AsmSigOp>();
            switch(src.OpKind)
            {
                case K.GpRm:
                {
                    var value = (GpRmToken)src.Value;
                    switch(value)
                    {
                        case GpRmToken.rm8:
                            dst.Add(new AsmSigOp(K.GpReg, (byte)(GpRegToken.r8)));
                            dst.Add(new AsmSigOp(K.GpReg, (byte)(MemToken.m8)));
                        break;
                    }
                }
                break;
                default:
                    dst.Add(src);
                break;
            }

            return dst.ToArray();
        }
    }
}