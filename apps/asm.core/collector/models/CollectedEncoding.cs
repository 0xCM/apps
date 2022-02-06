//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    readonly struct CollectedEncoding : IEquatable<CollectedEncoding>, IComparable<CollectedEncoding>
    {
        public readonly ApiToken Token;

        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public CollectedEncoding(ApiToken token, BinaryCode code)
        {
            Token = token;
            Code = code;
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

        public override int GetHashCode()
            => (int)Token.EntryId;

        [MethodImpl(Inline)]
        public bool Equals(CollectedEncoding src)
            => Token.Equals(src.Token);

        public override bool Equals(object src)
            => src is CollectedEncoding x && Equals(x);

        public int CompareTo(CollectedEncoding src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);
    }
}