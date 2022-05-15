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

        internal Index<char> ExprData;

        internal Index<uint> ExprLengths;

        internal Index<uint> ExprOffsets;

        internal Index<SymVal> Values;

        public uint SymbolCount {get; internal set;}

        internal uint EntryCount;

        [MethodImpl(Inline), Op]
        public ref readonly Identifier Source(uint index)
            => ref Sources[index];

        [Op]
        public ref readonly Identifier Name(uint index)
            => ref Names[index];

        [MethodImpl(Inline), Op]
        public ref readonly uint Offset(uint index)
            => ref ExprOffsets[index];

        [MethodImpl(Inline), Op]
        public ref readonly uint Width(uint index)
            => ref ExprLengths[index];

        [MethodImpl(Inline), Op]
        public ref readonly SymVal Value(uint index)
            => ref Values[index];

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<char> Expression(uint index)
            => api.expr(this, index);
    }
}