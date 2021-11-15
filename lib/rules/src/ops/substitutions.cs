//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct RuleModels
    {
        /// <summary>
        /// Defines a <see cref='Substitution{T}' set
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T">The data type</typeparam>
        [Op, Closures(Closure)]
        public static Substitutions<T> substitutions<T>(Index<Substitution<T>> src)
        {
            var count = (uint)src.Length;
            var sources = alloc<T>(count);
            var targets = alloc<T>(count);

            ref var input = ref src.First;
            ref var s = ref first(sources);
            ref var t = ref first(targets);

            for(var i=0; i<count; i++)
            {
                input = ref seek(input, i);
                s = ref seek(s,i);
                t = ref seek(t,i);
                s = input.Match;
                t = input.Replace;
            }

            return new Substitutions<T>(count, sources, targets);
        }
    }
}