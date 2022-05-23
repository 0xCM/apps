//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SymHeap
    {
        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}",src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        internal Index<Identifier> Sources;

        internal Index<Identifier> Names;

        internal Index<char> Expr;

        internal Index<uint> ExprLengths;

        internal Index<uint> ExprOffsets;

        internal Index<SymVal> Values;

        public uint SymbolCount {get; internal set;}

        internal uint EntryCount;

        public uint CharCount;

        [MethodImpl(Inline), Op]
        public ref Identifier Source(uint index)
            => ref Sources[index];

        [MethodImpl(Inline), Op]
        public ref Identifier Name(uint index)
            => ref Names[index];

        [MethodImpl(Inline), Op]
        public ref uint Offset(uint index)
            => ref ExprOffsets[index];

        [MethodImpl(Inline), Op]
        public ref uint Length(uint index)
            => ref ExprLengths[index];

        [MethodImpl(Inline), Op]
        public uint Size(uint index)
            => Length(index)*2;

        [MethodImpl(Inline), Op]
        public ref SymVal Value(uint index)
            => ref Values[index];

        [MethodImpl(Inline), Op]
        public Span<char> Symbol(uint index)
            => expr(this, index);
    }
}