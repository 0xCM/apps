//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines the content of a set of binary resources for an api host
    /// </summary>
    public readonly struct ApiHostRes
    {
        public ApiHostUri Host {get;}

        public Index<BinaryResSpec> Data {get;}

        [MethodImpl(Inline)]
        public ApiHostRes(ApiHostUri host, BinaryResSpec[] src)
        {
            Host = host;
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly BinaryResSpec this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public static ApiHostRes Empty
            => new ApiHostRes(ApiHostUri.Empty, array<BinaryResSpec>());
    }
}