//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiMemberExtract : IComparable<ApiMemberExtract>
    {
        public ApiExtractBlock Block {get; private set;}

        public readonly OpUri OpUri;

        public readonly ApiMember Member;

        [MethodImpl(Inline)]
        public ApiMemberExtract(ApiMember member, ApiExtractBlock block)
        {
            OpUri = member.OpUri;
            Member = member;
            Block = block;
        }

        // public ApiMemberExtract WithBlock(ApiExtractBlock block)
        // {
        //     Block = block;
        //     return this;
        // }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Block.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Block.IsNonEmpty;
        }

        public MethodInfo Method
            => Member.Method;

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Block.BaseAddress;
        }

        public MemoryRange Origin
        {
            [MethodImpl(Inline)]
            get => Block.Origin;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Member.Host;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Block.Format();

        [MethodImpl(Inline)]
        public bool Equals(ApiMemberExtract src)
            => Block.Equals(src.Block);

        [MethodImpl(Inline)]
        public int CompareTo(ApiMemberExtract src)
            => Block.BaseAddress.CompareTo(src.BaseAddress);

        public static ApiMemberExtract Empty
            => new ApiMemberExtract(ApiMember.Empty, ApiExtractBlock.Empty);
    }
}