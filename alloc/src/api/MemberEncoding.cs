//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemberEncoding
    {
        public readonly ApiToken Token;

        readonly uint _Size;

        [MethodImpl(Inline)]
        public MemberEncoding(ApiToken token, uint size)
        {
            Token = token;
            _Size = size;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public ulong Id
        {
            [MethodImpl(Inline)]
            get => Token.Id;
        }

        public MemoryAddress EntryAddress
        {
            [MethodImpl(Inline)]
            get => Token.EntryAddress;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Token.TargetAddress;
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

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => core.cover(TargetAddress.Ref<byte>(), _Size);
        }

        [MethodImpl(Inline)]
        public bool Equals(MemberEncoding src)
            => Token.Equals(src.Token);

        public override bool Equals(object src)
            => src is MemberEncoding x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(MemberEncoding src)
            => Token.EntryAddress.CompareTo(src.Token.EntryAddress);
    }
}