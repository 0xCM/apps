//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static T extract<F,T>(BfDataset<F,T> bitfield, F field, T src)
            where F : unmanaged, Enum
            where T : unmanaged
                => Bitfields.extract(src, (byte)bitfield.Offset(field), bitfield.Width(field));
    }
}