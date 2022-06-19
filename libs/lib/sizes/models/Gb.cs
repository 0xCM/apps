//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sizes;

    public readonly struct Gb
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


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Gb src)
            => Count == src.Count;

        public override int GetHashCode()
            => (int)alg.hash.calc(Count);

        public override bool Equals(object obj)
            => obj is Gb x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator ==(Gb a, Gb b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Gb a, Gb b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator uint(Gb src)
            => src.Count;
    }
}