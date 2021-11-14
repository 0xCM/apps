//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct SymHeapStorage
    {
        public uint EntryCount {get;}

        public uint SymbolCount {get;}

        readonly Index<char> _SymExpr;

        readonly Index<uint> _Offsets;

        readonly Index<ushort> _Widths;

        readonly Index<ushort> _Values;

        [MethodImpl(Inline)]
        public SymHeapStorage(uint entries, uint symbols, in Index<char> expr, in Index<uint> offsets, in Index<ushort> widths, in Index<ushort> values)
        {
            EntryCount = entries;
            SymbolCount = symbols;
            _SymExpr = expr;
            _Offsets = offsets;
            _Widths = widths;
            _Values = values;
        }

        public ReadOnlySpan<char> SymExpr
        {
            [MethodImpl(Inline), Op]
            get => _SymExpr.View;
        }

        public ReadOnlySpan<byte> SymExprData
        {
            [MethodImpl(Inline), Op]
            get => recover<byte>(SymExpr);
        }

        public ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline), Op]
            get => _Offsets.View;
        }

        public ReadOnlySpan<byte> OffsetData
        {
            [MethodImpl(Inline), Op]
            get => recover<byte>(Offsets);
        }

        public ReadOnlySpan<ushort> Values
        {
            [MethodImpl(Inline), Op]
            get => _Values.View;
        }

        public ReadOnlySpan<byte> ValueData
        {
            [MethodImpl(Inline), Op]
            get => recover<byte>(Values);
        }
    }
}