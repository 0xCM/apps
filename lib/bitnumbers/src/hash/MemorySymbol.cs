//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct MemorySymbol : IRecord<MemorySymbol>, IComparable<MemorySymbol>, IEquatable<MemorySymbol>
    {
        public uint Key;

        public Hash32 HashCode;

        public MemoryAddress Address;

        public ByteSize Size;

        public SymExpr Expr;

        [MethodImpl(Inline)]
        public MemorySymbol(uint key, Hash32 hash, MemoryAddress address, ByteSize size, SymExpr expr)
        {
            Key = key;
            HashCode = hash;
            Address = address;
            Size = size;
            Expr = expr;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address.IsEmpty && Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public static MemorySymbol Empty
        {
            [MethodImpl(Inline)]
            get => new MemorySymbol(0, 0, 0, 0, SymExpr.Empty);
        }

        [MethodImpl(Inline)]
        public int CompareTo(MemorySymbol src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(MemorySymbol src)
            => Address.Equals(src.Address);

        public override int GetHashCode()
            => (int)HashCode;
    }
}