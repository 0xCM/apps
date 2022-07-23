//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    public readonly struct Mb
    {
        public const string UOM = "mb";

        public readonly uint Count;

        [MethodImpl(Inline)]
        public Mb(uint src)
        {
            Count = src;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public string Format()
        {
            var value = Count != 0 ? Count.ToString("#,#") : "0";
            return string.Format("{0} {1}", value, UOM);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Mb src)
            => Count == src.Count;

        public override int GetHashCode()
            => (int)Count;

        public override bool Equals(object obj)
            => obj is Mb x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator ==(Mb a, Mb b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Mb a, Mb b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator uint(Mb src)
            => src.Count;
    }
}