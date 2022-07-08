//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct VarName<T>
        where T : unmanaged, IAsciSeq<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public VarName(T name)
        {
            Data = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsNull;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(VarName<T> src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(VarName<T> src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VarName<T>(T src)
            => new VarName<T>(src);
    }
}