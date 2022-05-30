//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmOcDatasets
    {
        static AsmOcDatasets _Instance;

        static object locker = new object();

        public static Index<AsmToken> tokens()
        {
            var srcA = typeof(AsmOcTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>().SelectMany(x => Symbols.tokenize<AsmOcTokenKind>(x));
            var srcB = Symbols.tokenize(typeof(Hex8Kind));
            var count = srcA.Length + srcB.Length;
            var dst = alloc<AsmToken>(count);
            var j=0u;
            for(var i=0; i<srcA.Length; i++, j++)
            {
                ref readonly var t = ref skip(srcA,i);
                ref var token = ref seek(dst,j);
                token = AsmOpCodes.generalize(t);
                token.Seq = j;
            }

            for(var i=0; i<srcB.Length; i++, j++)
            {
                ref readonly var item = ref srcB[i];
                ref var target = ref seek(dst,j);
                var token = new AsmOcToken(AsmOcTokenKind.Hex8, (byte)item.Value);
                target.Seq = j;
                target.Id = token.Id;
                target.ClassName = nameof(AsmOcToken);
                target.KindName = nameof(AsmOcTokenKind.Hex8);
                target.KindValue = (byte)token.Kind;
                target.Index = (ushort)item.Key;
                target.Name = item.Name;
                target.Value = token.Value;
                target.Expression = token.Value.FormatHex(specifier:false,uppercase:true);
            }

            var distinct = AsmTokens.unique(dst, out var dupe);
            if(!distinct)
                Errors.Throw(string.Format("{0} is not unique", dupe));

            return dst;
        }

        public static AsmOcDatasets load()
        {
            lock(locker)
            {
                if(_Instance == null)
                {
                    var dst = new AsmOcDatasets();
                    var kinds = Symbols.index<AsmOcTokenKind>();
                    var ts = AsmOcTokenSet.create();
                    var tokenExpr = dict<uint,string>();
                    var exprToken = dict<string,AsmOcToken>();
                    var tokes = tokens();
                    var tokencount = tokes.Count;
                    dst.Tokens = tokes.Map(x => AsmOpCodes.token((AsmOcTokenKind)x.KindValue, x.Value));
                    dst.TokenKindSymbols = kinds;

                    for(var i=0; i<tokencount; i++)
                    {
                        ref readonly var token = ref tokes[i];
                        var @class = token.KindName.Content;
                        if(kinds.ExprKind(@class, out var kind))
                        {
                            var oct = new AsmOcToken(kind, (byte)token.Value);
                            var xpr = token.Expression;
                            tokenExpr[oct.Id] = xpr;
                            exprToken[xpr] = oct;

                        }
                        else
                            Errors.Throw(string.Format("Kind for {0} not found", @class));
                    }

                    dst.TokenExpressions = tokenExpr;
                    dst.TokensByExpression = exprToken;
                    _Instance = dst;
                }
                return _Instance;
            }
        }

        public Index<AsmOcToken> Tokens {get; private set;}

        public ConstLookup<uint,string> TokenExpressions {get; private set;}

        public ConstLookup<string,AsmOcToken> TokensByExpression {get; private set;}

        public Symbols<AsmOcTokenKind> TokenKindSymbols {get; private set;}

        AsmOcDatasets()
        {
        }
    }
}