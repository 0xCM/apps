//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = SymHeaps;

    public class SymHeapSpec
    {
        internal Index<char> Expressions;

        internal Index<ushort> Widths;

        internal Index<uint> Offsets;

        internal Index<ushort> Values;

        internal Index<Identifier> Identifiers;

        public uint SymbolCount {get; internal set;}

        internal uint EntryCount;

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<char> SymChars(ushort index)
            => api.symchars(this, index);

        [Op]
        public SymExpr Expression(ushort index)
            => api.symexpr(this, index);

        [Op]
        public ref readonly Identifier Identifier(ushort index)
            => ref api.identifier(this,index);

        [MethodImpl(Inline), Op]
        public ref SymHeapStorage Storage(out SymHeapStorage dst)
        {
            dst = new SymHeapStorage(EntryCount, SymbolCount, Expressions, Offsets, Widths, Values);
            return ref dst;
        }
    }
}