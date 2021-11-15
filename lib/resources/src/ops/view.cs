//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Resources
    {
        /// <summary>
        /// Reveals the data represented by a <see cref='Asset'/>
        /// </summary>
        /// <param name="src">The source descriptor</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset src)
            => core.view(src.Address, src.Size);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<T> view<T>(in Asset<T> id)
            where T : unmanaged
                => core.view<T>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> id)
            => core.view<byte>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in Asset<char> id)
            => core.view<char>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public unsafe static ReadOnlySpan<char> view(in Asset<char> res, uint i0, uint i1)
            => core.section((char*)res.Address, i0, i1);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> res, uint i0, uint i1)
            => core.view<byte>(res.Address, (i1 - i0 + 1));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in StringResRow src)
            => core.view<char>(src.Address, src.Length);
    }
}