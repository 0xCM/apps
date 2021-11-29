//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AddressHash : IRecord<AddressHash>, IComparable<AddressHash>
    {
        public const string TableId = "addresses.hashed";

        public uint Index;

        public uint HashCode;

        public MemoryAddress Address;

        [MethodImpl(Inline)]
        public int CompareTo(AddressHash src)
            => Address.CompareTo(src.Address);
    }
}