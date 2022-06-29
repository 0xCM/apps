//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct ApiToken
    {
        readonly LocatedSymbol Entry;

        readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public ApiToken(LocatedSymbol entry, LocatedSymbol impl)
        {
            Entry = entry;
            Target = impl;
        }

        public Hex64 Id
        {
            [MethodImpl(Inline)]
            get => (ulong)EntryAddress.Lo | ((ulong)TargetAddress.Lo << 32);
        }

        public uint EntryId
        {
            [MethodImpl(Inline)]
            get => Entry.Location.Hash | Entry.Name.Address.Hash;
        }

        public uint TargetId
        {
            [MethodImpl(Inline)]
            get => Target.Location.Hash | Target.Name.Address.Hash;
        }

        public MemoryAddress EntryAddress
        {
            [MethodImpl(Inline)]
            get => Entry.Location;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Target.Location;
        }

        public Label Uri
        {
            [MethodImpl(Inline)]
            get => Entry.Name;
        }

        public Label Sig
        {
            [MethodImpl(Inline)]
            get => Target.Name;
        }

        public ApiHostUri Host
        {
            get
            {
                if(ApiUri.parse(Uri.Format(), out var uri))
                    return uri.Host;
                else
                    return ApiHostUri.Empty;
            }
        }

        public bool IsStubbed
        {
            [MethodImpl(Inline)]
            get => EntryAddress != TargetAddress;
        }

        public bool Equals(ApiToken src)
            => Entry.Equals(src.Entry) && Target.Equals(src.Target);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => EntryAddress.Hash | TargetAddress.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public static ApiToken Empty => default;
    }
}