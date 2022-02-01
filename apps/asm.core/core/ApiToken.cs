//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiToken
    {
        public static ApiToken create(SymbolDispenser symbols, in MethodEntryPoint entry, MemoryAddress target)
            => new ApiToken(symbols.Add(entry.Location, entry.Uri.Format()), symbols.Add(target, entry.Sig.Format()));

        public static ApiToken create(SymbolDispenser symbols, in MethodEntryPoint entry)
            => new ApiToken(symbols.Add(entry.Location, entry.Uri.Format()), symbols.Add(entry.Location, entry.Sig.Format()));

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
            get => Entry.Id;
        }

        public uint TargetId
        {
            [MethodImpl(Inline)]
            get => Target.Id;
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