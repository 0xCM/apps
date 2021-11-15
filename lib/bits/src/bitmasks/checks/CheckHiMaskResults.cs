//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CheckHiMaskResults<T> : IIndex<CheckHiMaskResult<T>>
    {
        readonly Index<CheckHiMaskResult<T>> Data;

        public CheckHiMaskResult<T>[] Storage
            => Data;

        [MethodImpl(Inline)]
        public CheckHiMaskResults(CheckHiMaskResult<T>[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public CheckHiMaskResults<T> Refresh(CheckHiMaskResult<T>[] src)
            => new CheckHiMaskResults<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator CheckHiMaskResults<T>(CheckHiMaskResult<T>[] src)
            => new CheckHiMaskResults<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Span<CheckHiMaskResult<T>>(CheckHiMaskResults<T> src)
            => src.Storage;
    }
}