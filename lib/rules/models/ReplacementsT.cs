//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Replacements<T>
    {
        readonly Index<ReplaceRule<T>> Data {get;}

        [MethodImpl(Inline)]
        public Replacements(ReplaceRule<T>[] src)
        {
            Data=src;
        }

        public ReadOnlySpan<ReplaceRule<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public static implicit operator Replacements<T>(ReplaceRule<T>[] src)
            => new Replacements<T>(src);
    }
}