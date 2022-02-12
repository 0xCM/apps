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

        public static bool nonterminal(in AsmSig src, out byte index)
        {
            ref readonly var ops = ref src.Operands;
            var result = false;
            index = default;
            for(var i=z8; i<src.OpCount; i++)
            {
                var op = src[i];
                switch(op.Kind)
                {
                    case K.VecRm:
                    case K.KRm:
                    case K.GpRm:
                    case K.MmxRm:
                    case K.BCastComposite:
                        result = true;
                        index = i;
                    break;
                }

                if(result)
                    break;
            }

            return result;
        }

        public static bool nonterminal(in AsmSigOp op)
        {
            var result = false;
            switch(op.Kind)
            {
                case K.VecRm:
                case K.KRm:
                case K.GpRm:
                case K.MmxRm:
                case K.BCastComposite:
                    result = true;
                break;
            }
            return false;
        }
    }
}