//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CellTypeParser : IParser<PrimalCellType>
    {
        public static CellTypeParser Service => default;

        [Parser]
        public static Outcome parse(string src, out PrimalCellType dst)
        {
            var input = text.trim(src);
            var result = Outcome.Failure;
            dst = PrimalCellType.Empty;
            if(text.empty(input))
                return result;

            var length = input.Length;
            var q = length - 1;

            var i = text.index(input, Chars.Colon);
            if(!PrimitiveParser.parse(input, out var pc))
                return result.Fail;

            if(i >= 0)
            {
                var l = text.index(input,Chars.LParen);
                var r = text.index(input,Chars.RParen);
                if(l >= 0 && r>=0)
                {
                    var b = text.inside(input,l,r);
                    var k = text.index(b, Chars.Colon);
                    if(k >=0)
                    {
                        var cw = text.left(b,k);
                        var sw = text.right(b,k);
                        if(uint.TryParse(cw, out var ncw))
                        {
                            if(uint.TryParse(sw, out var nsw))
                            {
                                var c = text.right(input,r);
                                dst = new PrimalCellType(ncw,nsw,pc);
                                result = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if(q != 0)
                {
                    if(uint.TryParse(text.left(input, q), out var n))
                    {
                        dst = new PrimalCellType(n,n,pc);
                        result = true;
                    }
                }
            }
            return result;
        }

        public Outcome Parse(string src, out PrimalCellType dst)
            => parse(src, out dst);
    }
}