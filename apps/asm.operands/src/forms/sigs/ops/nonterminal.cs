//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using K = AsmSigTokenKind;

    partial class AsmSigs
    {
        public static bool nonterminal(in AsmSig src, out byte index, out byte count)
        {
            ref readonly var ops = ref src.Operands;
            var result = false;
            count = 0;
            index = default;
            for(var i=z8; i<src.OpCount; i++)
            {
                var op = src[i];
                if(nonterminal(op, out count))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static bool nonterminal(in AsmSigOp op, out byte count)
        {
            var result = false;
            count = 0;
            switch(op.Kind)
            {
                case K.VecRm:
                case K.KRm:
                case K.GpRm:
                case K.MmxRm:
                    result = true;
                    count = 2;
                    break;
                case K.GpRegTriple:
                case K.GpRmTriple:
                case K.BCastComposite:
                    result = true;
                    count = 3;
                break;
            }
            return result;
        }
    }
}