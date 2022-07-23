//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    public readonly record struct Gb : IDataType<Gb>
    {
        public const string UOM = "gb";

        public readonly uint Count;

        [MethodImpl(Inline)]
        public Gb(uint src)
        {
            Count = src;
        }

        public string Format()
        {
            var value = Count != 0 ? Count.ToString("#,#") : "0";
            return string.Format("{0} {1}", value, UOM);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Size);
        }

        [MethodImpl(Inline)]
        public int CompareTo(Gb src)
            => Size.CompareTo(src.Size);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Gb src)
            => Count == src.Count;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator uint(Gb src)
            => src.Count;
    }
}