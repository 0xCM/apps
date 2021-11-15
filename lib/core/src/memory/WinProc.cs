//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WinProc : IComparable<WinProc>, IEquatable<WinProc>
    {
        public uint ProcessId {get;}

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public WinProc(uint id, MemoryAddress address)
        {
            ProcessId = id;
            Address = address;
        }

        [MethodImpl(Inline)]
        public unsafe void* Pointer()
            => Address.Pointer();

        [MethodImpl(Inline)]
        public int CompareTo(WinProc src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(WinProc src)
            => ProcessId == src.ProcessId && Address == src.Address;

        public override int GetHashCode()
            => (int)Address.Hash;

        public override bool Equals(object src)
            => src is WinProc s && Equals(s);

        [MethodImpl(Inline)]
        public static implicit operator WinProc((int id, MemoryAddress address) src)
            => new WinProc((uint)src.id, src.address);

        [MethodImpl(Inline)]
        public static implicit operator WinProc((uint id, MemoryAddress address) src)
            => new WinProc((uint)src.id, src.address);
    }
}