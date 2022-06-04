//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a member that defines a resource
    /// </summary>
    public readonly struct ResMember : ITextual
    {
        public MemberInfo Member {get;}

        public MemorySeg Segment {get;}

        [MethodImpl(Inline)]
        public ResMember(MemberInfo member, MemorySeg seg)
        {
            Member = member;
            Segment = seg;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Segment.BaseAddress;
        }

        public uint DataSize
        {
            [MethodImpl(Inline)]
            get => Segment.Length;
        }

        public string Format()
            => $"{Member.Name} {Segment.Format()}";
    }
}