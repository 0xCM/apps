//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    partial struct AsmParser
    {
        public static Outcome directive(string src, out AsmDirective dst)
        {
            var input = src.Trim();
            var name = input;
            var i = text.index(src, Chars.Dot);
            var j = text.index(src, Chars.Colon);
            var result = Outcome.Failure;
            if(i >= 0 && j < 0)
            {
                var k = text.index(src, Chars.Comma);
                if(k > 0)
                {
                    name = text.left(src,k).Trim();
                    var args = text.right(src,i).SplitClean(Chars.Comma);
                    var count =  args.Length;
                    switch(count)
                    {
                        case 1:
                            dst = asm.directive(name, skip(args,0));
                        break;
                        case 2:
                            dst = asm.directive(name, skip(args,0), skip(args,1));
                        break;
                        case 3:
                            dst = asm.directive(name, skip(args,0), skip(args,1), skip(args,2));
                        break;
                        default:
                            dst = asm.directive(name);
                        break;
                    }
                }
                else
                    dst = asm.directive(name);

                result = Outcome.Success;
            }
            else
                dst = AsmDirective.Empty;

            return result;
        }
    }
}