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
        public static string format(in RuleExpr src)
        {
            var sep = " <=> ";
            var dst = text.buffer();
            render(src.Premise, dst);
            var a = dst.Emit();

            render(src.Consequent, dst);
            var b = dst.Emit();

            if(empty(a) && empty(b))
                return EmptyString;
            else if(empty(a) && nonempty(b))
                return string.Format("_{0}{1}", sep, b);
            else if(nonempty(a) && empty(b))
                return string.Format("{0}{1}_", a, sep);
            else
                return string.Format("{0}{1}{2}",a,sep,b);
        }

        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(" && ");
                dst.Append(format(skip(src,i)));
            }
        }
    }
}