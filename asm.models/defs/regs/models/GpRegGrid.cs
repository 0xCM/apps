//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmRegTokens;

    public readonly struct GpRegGrid
    {
        Index<RegOp> Data {get;}

        [MethodImpl(Inline)]
        internal GpRegGrid(RegOp[] src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<RegOp> Row(GpRegKind kind)
        {
            var offset = (byte)kind * 16;
            var length = kind == GpRegKind.Gp8Hi ? 4 : 16;
            return slice(Data.View, offset, length);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public static GpRegGrid Empty
        {
            [MethodImpl(Inline)]
            get => new GpRegGrid(array<RegOp>());
        }
    }
}