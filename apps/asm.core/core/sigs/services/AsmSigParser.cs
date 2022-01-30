//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class AsmSigParser
    {
        AsmSigDatasets Datasets;

        public AsmSigParser()
        {
            Datasets = AsmSigDatasets.load();
        }

        public static AsmMnemonic partition(string src, out Index<AsmSigOpExpr> dst)
        {
            var input = text.trim(text.despace(src));
            var i= text.index(input, Chars.Space);
            if(i > 0)
                dst = map(text.trim(text.split(text.right(input,i), Chars.Comma)), x => new AsmSigOpExpr(x));
            else
                dst = sys.empty<AsmSigOpExpr>();

            return AsmMnemonic.parse(input, out _);
        }

        [Parser]
        public static Outcome parse(string src, out AsmSig dst)
        {
            var result = Outcome.Success;
            dst = AsmSig.Empty;
            var mnemonic = partition(src, out var ops);
            var count = ops.Length;
            switch(count)
            {
                case 0:
                {
                    dst = new AsmSig(mnemonic);
                }
                break;
                case 1:
                {
                    ref readonly var op0src = ref ops[0];
                    result = operand(op0src, out var op0);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op0), op0src));
                        break;
                    }

                    dst = new AsmSig(mnemonic, op0);
                }
                break;
                case 2:
                {
                    ref readonly var op0src = ref ops[0];
                    ref readonly var op1src = ref ops[1];
                    result = operand(op0src, out var op0);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op0), op0src));
                        break;
                    }

                    result = operand(op1src, out var op1);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op1), op1src));
                        break;
                    }


                    dst = new AsmSig(mnemonic, op0, op1);
                }
                break;
                case 3:
                {
                    ref readonly var op0src = ref ops[0];
                    ref readonly var op1src = ref ops[1];
                    ref readonly var op2src = ref ops[2];
                    result = operand(op0src, out var op0);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op0), op0src));
                        break;
                    }

                    result = operand(op1src, out var op1);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op1), op1src));
                        break;
                    }

                    result = operand(op2src, out var op2);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op2), op2src));
                        break;
                    }

                    dst = new AsmSig(mnemonic, op0, op1, op2);
                }
                break;
                case 4:
                {
                    ref readonly var op0src = ref ops[0];
                    ref readonly var op1src = ref ops[1];
                    ref readonly var op2src = ref ops[2];
                    ref readonly var op3src = ref ops[3];
                    result = operand(op0src, out var op0);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op0), op0src));
                        break;
                    }

                    result = operand(op1src, out var op1);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op1), op1src));
                        break;
                    }

                    result = operand(op2src, out var op2);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op2), op2src));
                        break;
                    }

                    result = operand(op3src, out var op3);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op3), op3src));
                        break;
                    }

                    dst = new AsmSig(mnemonic, op0, op1, op2, op3);
                }
                break;
                case 5:
                {
                    ref readonly var op0src = ref ops[0];
                    ref readonly var op1src = ref ops[1];
                    ref readonly var op2src = ref ops[2];
                    ref readonly var op3src = ref ops[3];
                    ref readonly var op4src = ref ops[4];
                    result = operand(op0src, out var op0);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op0), op0src));
                        break;
                    }

                    result = operand(op1src, out var op1);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op1), op1src));
                        break;
                    }

                    result = operand(op2src, out var op2);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op2), op2src));
                        break;
                    }

                    result = operand(op3src, out var op3);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op3), op3src));
                        break;
                    }

                    result = operand(op3src, out var op4);
                    if(result.Fail)
                    {
                        result = (false, OpParseError.Format(nameof(op4), op4src));
                        break;
                    }

                    dst = new AsmSig(mnemonic, op0, op1, op2, op3, op4);
                }
                break;
            }

            return result;
        }

        static MsgPattern<string,AsmSigOpExpr> OpParseError => "Unable to parse {0} from '{1}'";

        static bool operand(AsmSigOpExpr src, out AsmSigOp dst)
        {
            if(src.Modified(out var op, out var mod))
            {
                if(_Datasets.TokensByExpression.Find(op, out dst))
                {
                    dst = dst.WithModifier(mod);
                    return true;
                }
                else
                    return false;
            }
            else
                return _Datasets.TokensByExpression.Find(src.Text, out dst);
        }

        public bool Token(string src, out AsmSigOp dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public Outcome Parse(string src, out AsmSig dst)
            => parse(src, out dst);

        static AsmSigParser()
        {
            _Datasets = AsmSigDatasets.load();
        }

        static AsmSigDatasets _Datasets;
    }
}