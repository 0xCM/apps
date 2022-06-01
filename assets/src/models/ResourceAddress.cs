//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe struct ResourceAddress : ITextual, IComparable<ResourceAddress>, IEquatable<ResourceAddress>
    {
        public ulong Location {get;}

        [MethodImpl(Inline)]
        public ResourceAddress(ulong location)
        {
            Location = location;
        }

        [MethodImpl(Inline)]
        public static implicit operator ResourceAddress(ulong src)
            => new ResourceAddress(src);

        public string Format()
            => Location.ToString("x");

        public override string ToString()
            => Format();

        public int CompareTo(ResourceAddress src)
            => Location.CompareTo(src.Location);

        public bool Equals(ResourceAddress src)
            => Location.Equals(src.Location);
    }
}