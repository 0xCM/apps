//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MemberAddress<T> : IAddressable<MemberAddress<T>, MemoryAddress>
        where T : IClrRuntimeMember
    {
        public T Member {get;}

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public MemberAddress(T member, MemoryAddress address)
        {
            Member = member;
            Address = address;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress<T>(Paired<T,MemoryAddress> src)
            => new MemberAddress<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress(MemberAddress<T> src)
            => new MemberAddress(new ClrMember(src.Member.Definition), src.Address);
    }
}