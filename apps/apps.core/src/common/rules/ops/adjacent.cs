//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Rules
    {
        [Op, Closures(Closure)]
        public static uint evaluate<T>(Adjacent<T> rule, ReadOnlySpan<T> src, Span<uint> dst)
            where T : IEquatable<T>
        {
            var terms = Math.Min(src.Length - 1, dst.Length);
            var matched = 0u;
            for(var i=0u; i<terms; i++)
            {
                ref readonly var s0 = ref skip(src, i);
                ref readonly var s1 = ref skip(src, i + 1);
                if((s0.Equals(rule.Content.Left) && s1.Equals(rule.Content.Right)))
                    seek(dst, matched++) = i;
            }
            return matched;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Adjacent<T> adjacent<T>(T a, T b)
            => new Adjacent<T>(a, b);

        public static LiteralRule<T> literal<T>(T value)
            => new LiteralRule<T>(value);
   }
}