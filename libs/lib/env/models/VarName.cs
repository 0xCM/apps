//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct VarName : INamed<VarName>
    {
        public readonly asci64 Data;

        [MethodImpl(Inline)]
        public VarName(asci64 data)
        {
            Data = data;
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
        public bool Equals(VarName src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(VarName src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VarName(string src)
            => new VarName(src);

        [MethodImpl(Inline)]
        public static implicit operator VarName(@string src)
            => new VarName(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator VarName(Identifier src)
            => new VarName(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator VarName(Name src)
            => new VarName(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator string(VarName src)
            => src.Data;
    }
}