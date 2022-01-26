//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;
    using static core;

    public class AsmSigDatasets
    {
        public AsmSigTokenSet TokenSet {get; private set;}

        public Index<AsmSigOp> Tokens {get; private set;}

        public ConstLookup<AsmSigOpKind,Index<AsmSigOp>> TokensByKind {get; private set;}

        public ConstLookup<AsmSigOp,string> TokenExpressions {get; private set;}

        public ConstLookup<string,AsmSigOp> TokensByExpression {get; private set;}

        public Symbols<AsmSigOpKind> TokenKindSymbols {get; private set;}

        AsmSigDatasets()
        {
        }

        static AsmSigDatasets _Instance;

        static object locker = new object();

        public static AsmSigDatasets load()
        {
            lock(locker)
            {
                if(_Instance == null)
                {
                    var dst = new AsmSigDatasets();
                    var kinds = Symbols.index<AsmSigOpKind>();
                    dst.TokenKindSymbols = kinds;
                    dst.TokenSet = AsmSigTokenSet.create();
                    var symtokens = dst.TokenSet.View;
                    var count = (uint)symtokens.Length;
                    dst.Tokens = alloc<AsmSigOp>(count);

                    var tokenExpr = dict<AsmSigOp,string>();
                    var exprToken = dict<string,AsmSigOp>();
                    var j=0;

                    for(var i=0; i<count; i++)
                    {
                        ref readonly var symtoken = ref skip(symtokens,i);
                        ref readonly var @class = ref symtoken.Class;
                        if(kinds.ExprKind(@class.Kind, out var kind))
                        {
                            var sigtoken = new AsmSigOp(kind, (byte)symtoken.Value);
                            var xpr = symtoken.Expr.Text;
                            dst.Tokens[j++] = sigtoken;
                            tokenExpr[sigtoken] = xpr;
                            exprToken[xpr] = sigtoken;

                        }
                        else
                            Errors.Throw(string.Format("Kind for {0} not found", @class.Kind));
                    }

                    dst.TokensByKind = dst.Tokens.GroupBy(t => t.OpKind).Select(x => (x.Key, (Index<AsmSigOp>)x.Array())).ToDictionary();
                    dst.TokenExpressions = tokenExpr;
                    dst.TokensByExpression = exprToken;
                    _Instance = dst;
                }

                return _Instance;
            }
        }
    }
}