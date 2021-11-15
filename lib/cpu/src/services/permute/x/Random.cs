//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static class PRngX
    {
        /// <summary>
        /// Shuffles a copy of the source permutation, leaving the original intact.
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="perm">The permutation</param>
        [MethodImpl(Inline)]
        public static perm Shuffle(this IBoundSource src, in perm perm)
        {
            var copy = perm.Replicate();
            var count = copy.Length;
            for(var i=0; i<count; i++)
                perm.Swap(i,src.Next<int>(0, count));
            return copy;
        }
    }
}