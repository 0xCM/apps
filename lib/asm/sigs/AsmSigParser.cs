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

        [Parser]
        public static Outcome parse(string src, out AsmSig dst)
        {
            var result = Outcome.Success;
            dst = AsmSig.Empty;
            var input = text.trim(text.despace(src));
            var k = text.index(input, Chars.Space);
            var mnemonic = AsmMnemonic.Empty;

            if(k > 0)
                mnemonic = AsmMnemonic.parse(text.left(input,k), out _);
            else
                mnemonic = src;

            var ops = k > 0 ? text.trim(text.split(text.right(input, k), Chars.Comma)) : sys.empty<string>();
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
                    ref readonly var op0src = ref skip(ops,0);
                    result = ParseOp(op0src, out var op0);
                    if(result.Fail)
                        break;

                    dst = new AsmSig(mnemonic, op0);
                }
                break;
                case 2:
                {
                    ref readonly var op0src = ref skip(ops,0);
                    ref readonly var op1src = ref skip(ops,1);
                    result = ParseOp(op0src, out var op0);
                    if(result.Fail)
                        break;

                    result = ParseOp(op1src, out var op1);
                    if(result.Fail)
                        break;

                    dst = new AsmSig(mnemonic, op0, op1);
                }
                break;
                case 3:
                {
                    ref readonly var op0src = ref skip(ops,0);
                    ref readonly var op1src = ref skip(ops,1);
                    ref readonly var op2src = ref skip(ops,2);
                    result = ParseOp(op0src, out var op0);
                    if(result.Fail)
                        break;

                    result = ParseOp(op1src, out var op1);
                    if(result.Fail)
                        break;

                    result = ParseOp(op2src, out var op2);
                    if(result.Fail)
                        break;

                    dst = new AsmSig(mnemonic, op0, op1, op2);

                }
                break;
                case 4:
                {
                    ref readonly var op0src = ref skip(ops,0);
                    ref readonly var op1src = ref skip(ops,1);
                    ref readonly var op2src = ref skip(ops,2);
                    ref readonly var op3src = ref skip(ops,3);
                    result = ParseOp(op0src, out var op0);
                    if(result.Fail)
                        break;

                    result = ParseOp(op1src, out var op1);
                    if(result.Fail)
                        break;

                    result = ParseOp(op2src, out var op2);
                    if(result.Fail)
                        break;

                    result = ParseOp(op3src, out var op3);
                    if(result.Fail)
                        break;

                    dst = new AsmSig(mnemonic, op0, op1, op2, op3);

                }
                break;
            }

            return result;
        }

        static bool ParseOp(string src, out AsmSigOp dst)
            => _Datasets.TokensByExpression.Find(src, out dst);

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