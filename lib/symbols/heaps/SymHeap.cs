//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SymHeaps;

    public class SymHeap
    {
        internal Index<Identifier> Sources;

        internal Index<Identifier> Names;

        internal Index<char> Expressions;

        internal Index<uint> Widths;

        internal Index<uint> Offsets;

        internal Index<SymVal> Values;

        public uint SymbolCount {get; internal set;}

        internal uint EntryCount;

        [MethodImpl(Inline), Op]
        public ref readonly Identifier Source(uint index)
            => ref Sources[index];

        [Op]
        public ref readonly Identifier Name(uint index)
            => ref api.name(this, index);

        [MethodImpl(Inline), Op]
        public ref readonly uint Offset(uint index)
            => ref api.offset(this, index);

        [MethodImpl(Inline), Op]
        public ref readonly uint Width(uint index)
            => ref api.width(this, index);

        [MethodImpl(Inline), Op]
        public ref readonly SymVal Value(uint index)
            => ref Values[index];

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<char> SymChars(uint index)
            => api.symchars(this, index);

        [Op]
        public SymExpr Expression(uint index)
            => api.symexpr(this, index);
    }
}