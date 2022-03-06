//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public readonly struct ImmFieldSpec
        {
            public static ImmFieldSpec parse(string src)
            {
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var kind = Chars.x;
                var width = z8;
                var index = z8;
                if(i > 0 && j > i)
                {
                    var inside = text.inside(src,i,j);
                    var quotient = text.split(inside,Chars.FSlash);
                    if(quotient.Length != 2)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(DispFieldSpec), src));

                    ref readonly var upper = ref skip(quotient,0);
                    ref readonly var lower = ref skip(quotient,1);

                    if(upper.Length == 1)
                        kind = upper[0];
                    if(!byte.TryParse(lower, out width))
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(width), lower));

                }

                if(text.contains(src,"UIMM1"))
                    index = 1;

                return new ImmFieldSpec(index, width);
            }

            public readonly byte Index;

            public readonly byte Width;

            public ImmFieldSpec(byte index, byte width)
            {
                Index = index;
                Width = width;
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static ImmFieldSpec Empty => default;
        }
    }
}