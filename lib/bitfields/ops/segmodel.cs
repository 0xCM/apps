//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitfieldSegModel segmodel(text31 name, uint pos, uint min, uint max)
            => new BitfieldSegModel(name, pos, min, max);

        [MethodImpl(Inline), Op]
        public static BitfieldSegModel<K> segmodel<K>(uint pos, K segid, uint min, uint max)
            where K : unmanaged
                => new BitfieldSegModel<K>(segid, pos, min, max);
    }
}