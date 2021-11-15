//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using static core;
    using static ExprPatterns;

    using XF = ExprPatterns;

    partial struct rules
    {
        internal static string format<T>(in Between<T> src)
            => string.Format(InclusiveRange, src.Min, src.Max);

        internal static string format<T>(in Rule<T> src)
            where T : IExpr
                => string.Format(Definition, src.Name, src.Expr.Format());

        internal static string format<K,T>(in Branch<K,T> src)
            where T : IExpr
            where K : unmanaged
        {
            var dst = text.buffer();
            var margin = 0u;
            var choices = src.Choices;
            var terms = src.Targets;
            var count = choices.Length;
            dst.IndentLineFormat(margin, "{0}({1}) {", "branch", src.Name);
            margin += 2;
            for(var i=0; i<count; i++)
                dst.IndentLineFormat(margin, XF.BranchCase, skip(choices,i).Format(), skip(terms,i).Format());
            margin -=2;
            dst.IndentLine(margin, "}");

            return dst.Emit();
        }

        internal static string format(in Adjacent src)
            => string.Format(RP.Adjacent2,src.A, src.B);

        internal static string format<T>(in Adjacent<T> src)
            => string.Format(RP.Adjacent2,src.A, src.B);

        internal static string format<T>(in ItemMatch<T> src)
            where T : System.IEquatable<T>
                => string.Format("match({0})", src.Value);

        internal static string format<T>(in Replace<T> src)
            => string.Concat(
                string.Format("replace" + XF.AngledSlot0, typeof(T).Name),
                string.Format(XF.SourceToTarget, src.Match, src.Value)
                );
    }
}