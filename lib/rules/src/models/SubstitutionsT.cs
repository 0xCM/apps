//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Substitutions<T>
        {
            public uint Count {get;}

            readonly Index<T> Matches {get;}

            readonly Index<T> Replacements {get;}

            [MethodImpl(Inline)]
            internal Substitutions(uint count, T[] sources, T[] targets)
            {
                Count = count;
                Matches = sources;
                Replacements = targets;
            }

            [MethodImpl(Inline)]
            public ref readonly T Match(uint index)
                => ref Matches[index];

            [MethodImpl(Inline)]
            public ref readonly T Replace(uint index)
                => ref Replacements[index];
        }
    }
}