//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct EncodedMember : IEquatable<EncodedMember>, IComparable<EncodedMember>
    {
        public readonly ApiToken Token;

        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public EncodedMember(ApiToken token, BinaryCode code)
        {
            Token = token;
            Code = code;
        }

        public override int GetHashCode()
            => (int)Token.EntryId;

        [MethodImpl(Inline)]
        public bool Equals(EncodedMember src)
            => Token.Equals(src.Token);

        public override bool Equals(object src)
            => src is EncodedMember x && Equals(x);

        public int CompareTo(EncodedMember src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);
    }
}