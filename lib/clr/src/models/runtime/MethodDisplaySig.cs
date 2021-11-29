//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MethodDisplaySig
    {
        readonly TextBlock Content;

        [MethodImpl(Inline)]
        internal MethodDisplaySig(TextBlock src)
            => Content = src;

        [MethodImpl(Inline)]
        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        public static MethodDisplaySig Empty
        {
            [MethodImpl(Inline)]
            get => new MethodDisplaySig(TextBlock.Empty);
        }
    }
}