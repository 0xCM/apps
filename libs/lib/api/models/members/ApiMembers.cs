//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines and index over <see cref='ApiMember'/> values
    /// </summary>
    public struct ApiMembers : IIndex<ApiMember>
    {
        public readonly MemoryAddress BaseAddress;

        readonly Index<ApiMember> Data;

        [MethodImpl(Inline)]
        internal ApiMembers(MemoryAddress @base, Index<ApiMember> src)
        {
            BaseAddress = @base;
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ReadOnlySpan<ApiMember> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ApiMember[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Methods Methods
            => Data.Map(x => x.Method).Storage;

        public ReadOnlySpan<ApiMsil> Msil
            => Data.Map(x => x.Msil);

        public ReadOnlySpan<ClrMethodArtifact> Artifacts
            => Data.Map(x => x.Metadata);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public ref ApiMember this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ApiMember this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator ApiMember[](ApiMembers src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<ApiMember>(ApiMembers src)
            => src.Data;

        public static ApiMembers Empty
            => new ApiMembers(MemoryAddress.Zero, Index<ApiMember>.Empty);
    }
}