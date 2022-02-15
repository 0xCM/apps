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

        static readonly string[] HexData = new string[256]{"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D", "1E", "1F", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "2E", "2F", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B", "3C", "3D", "3E", "3F", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A", "5B", "5C", "5D", "5E", "5F", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D", "6E", "6F", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7A", "7B", "7C", "7D", "7E", "7F", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B", "8C", "8D", "8E", "8F", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F", "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "AA", "AB", "AC", "AD", "AE", "AF", "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "BF", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF", "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB", "DC", "DD", "DE", "DF", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "FA", "FB", "FC", "FD", "FE", "FF"};
    }
}