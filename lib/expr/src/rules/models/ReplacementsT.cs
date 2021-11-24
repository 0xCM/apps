//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Replacements<T>
    {
        readonly Index<Replace<T>> Data {get;}

        [MethodImpl(Inline)]
        public Replacements(Replace<T>[] src)
        {
            Data=src;
        }

        public ReadOnlySpan<Replace<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public static implicit operator Replacements<T>(Replace<T>[] src)
            => new Replacements<T>(src);
    }
}