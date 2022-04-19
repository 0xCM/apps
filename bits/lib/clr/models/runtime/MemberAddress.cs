//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MemberAddress : IAddressable<MemberAddress, MemoryAddress>, IComparable<MemberAddress>
    {
        public ClrMember Member {get;}

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public MemberAddress(ClrMember member, MemoryAddress address)
        {
            Member = member;
            Address = address;
        }

        public string Format()
            => string.Format("{0}: {1}", Address, Member.Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(MemberAddress src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress(Paired<ClrMember,MemoryAddress> src)
            => new MemberAddress(src.Left, src.Right);
    }
}