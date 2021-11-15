//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct BitfieldSpecs
    {
        [MethodImpl(Inline), Op]
        public static BitfieldSegModel segment(Identifier name, uint pos, uint offset, uint width)
            => new BitfieldSegModel(name, pos, offset, width);

        [MethodImpl(Inline), Op]
        public static BitfieldSegModel<K> segment<K>(uint pos, K segid, uint offset, uint width)
            where K : unmanaged
                => new BitfieldSegModel<K>(segid, pos, offset, width);
    }
}