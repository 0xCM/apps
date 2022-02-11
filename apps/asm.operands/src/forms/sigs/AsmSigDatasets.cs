//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;

    public class AsmSigDatasets
    {
        //public AsmSigTokenSet TokenSet {get; private set;}

        public Index<AsmSigOp> Tokens {get; private set;}

        public ConstLookup<AsmSigTokenKind,Index<AsmSigOp>> OpsByKind {get; private set;}

        public ConstLookup<uint,string> TokenExpressions {get; private set;}

        public ConstLookup<string,AsmSigOp> OpsByExpression {get; private set;}

        public Symbols<AsmModifierKind> Modifers {get; private set;}

        public ConstLookup<Type,AsmSigTokenKind> TypeKinds {get; private set;}

        public AsmSigTokenKind Kind(Type src)
            => TypeKinds[src];

        public ReadOnlySpan<AsmSigTokenKind> Kinds
            => TypeKinds.Values;

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
                    var kinds = Symbols.index<AsmSigTokenKind>();
                    var ts = AsmSigTokenSet.create();
                    dst.TypeKinds = ts.TypeKinds();
                    var symtokens = ts.View;
                    var count = (uint)symtokens.Length;
                    dst.Tokens = alloc<AsmSigOp>(count);

                    var tokenExpr = dict<uint,string>();
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
                            tokenExpr[sigtoken.Id] = xpr;
                            exprToken[xpr] = sigtoken;

                        }
                        else
                            Errors.Throw(string.Format("Kind for {0} not found", @class.Kind));
                    }

                    dst.OpsByKind = dst.Tokens.GroupBy(t => t.Kind).Select(x => (x.Key, (Index<AsmSigOp>)x.Array())).ToDictionary();
                    dst.TokenExpressions = tokenExpr;
                    dst.OpsByExpression = exprToken;
                    dst.Modifers = Symbols.index<AsmModifierKind>();
                    _Instance = dst;
                }

                return _Instance;
            }
        }
    }
}