//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public struct AddressHash : IComparable<AddressHash>
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