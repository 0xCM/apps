//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdOptionSpecs<K> : IIndexedView<CmdOptionSpecs<K>,ushort,CmdOptionSpec<K>>
        where K : unmanaged
    {
        readonly Index<CmdOptionSpec<K>> Data;

        [MethodImpl(Inline)]
        public CmdOptionSpecs(CmdOptionSpec<K>[] src)
            => Data = src;

        public CmdOptionSpec<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<CmdOptionSpec<K>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public string Format()
            => seq.format(Storage);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpecs<K>(CmdOptionSpec<K>[] src)
            => new CmdOptionSpecs<K>(src);
    }
}