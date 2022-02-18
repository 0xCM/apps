//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiToken
    {
        public static ApiToken create(SymbolDispenser symbols, in MethodEntryPoint entry, MemoryAddress target)
        {
            var e = symbols.Dispense(entry.Location, entry.Uri?.Format() ?? EmptyString);
            var t = symbols.Dispense(target, entry.Sig.Format());
            return new ApiToken(e, t);
        }

        public static ApiToken create(SymbolDispenser symbols, in MethodEntryPoint entry)
            => new ApiToken(symbols.Dispense(entry.Location, text.ifempty(entry.Uri.Format(),EmptyString)), symbols.Dispense(entry.Location, entry.Sig.Format()));

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
            get => alg.hash.combine(Entry.Location.Hash, (uint)Entry.Name.Address);
        }

        public uint TargetId
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine(Target.Location.Hash, (uint)Target.Name.Address);
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

        public static ApiToken Empty => default;
    }
}