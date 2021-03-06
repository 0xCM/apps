//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct CollectedEncoding : IDataType<CollectedEncoding>
    {
        public readonly ApiToken Token;

        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public CollectedEncoding(ApiToken token, BinaryCode code)
        {
            Token = token;
            Code = code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty;
        }

        public Label Uri
        {
            [MethodImpl(Inline)]
            get => Token.Uri;
        }

        public Label Sig
        {
            [MethodImpl(Inline)]
            get => Token.Sig;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Token.EntryId;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(CollectedEncoding src)
            => Token.Equals(src.Token);

        [MethodImpl(Inline)]
        public int CompareTo(CollectedEncoding src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);

        public static CollectedEncoding Empty => new (ApiToken.Empty, sys.empty<byte>());
    }
}