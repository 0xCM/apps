//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    public partial class XedRender
    {
        public static string format(in RuleStatement src)
        {
            var sep = " <=> ";
            var dst = text.buffer();
            render(src.Premise, dst);
            var a = dst.Emit();

            render(src.Consequent, dst);
            var b = dst.Emit();

            return string.Format("{0}{1}{2}", a, sep, b);
        }

        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(counter != 0)
                    dst.Append(" && ");

                dst.Append(format(c));
                counter++;
            }
        }
    }
}