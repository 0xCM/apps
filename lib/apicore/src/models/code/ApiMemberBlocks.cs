//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a sequence of <see cref='ApiMemberCode'/> records
    /// </summary>
    public readonly struct ApiMemberBlocks : IIndex<ApiMemberCode>
    {
        readonly Index<ApiMemberCode> Data;

        [MethodImpl(Inline)]
        public ApiMemberBlocks(ApiMemberCode[] src)
            => Data = src;

        public ReadOnlySpan<ApiMemberCode> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ApiMemberCode> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref ApiMemberCode First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ApiMemberCode[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref ApiMemberCode this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ApiMemberBlocks Filter(ApiClassKind @class)
            => Data.Where(b => b.Member.ApiClass == @class);

        [MethodImpl(Inline)]
        public static implicit operator ApiMemberBlocks(ApiMemberCode[] src)
            => new ApiMemberBlocks(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiMemberBlocks(Index<ApiMemberCode> src)
            => new ApiMemberBlocks(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiMemberCode[](ApiMemberBlocks src)
            => src.Storage;

        public static ApiMemberBlocks Empty
        {
            [MethodImpl(Inline)]
            get => new ApiMemberBlocks(sys.empty<ApiMemberCode>());
        }
    }
}