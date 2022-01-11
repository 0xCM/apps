//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using static core;

    public readonly struct SortingNetworks
    {
        public static SortingNetwork<T> define<T>()
            where T : unmanaged
        {
            var channels = alloc<Comparator<T>>(6);
            var i=0;
            seek(channels,i++) = new Comparator<T>();
            seek(channels,i++) = new Comparator<T>();
            seek(channels,i++) = new Comparator<T>();
            seek(channels,i++) = new Comparator<T>();
            seek(channels,i++) = new Comparator<T>();
            seek(channels,i++) = new Comparator<T>();
            return new SortingNetwork<T>(channels);
        }
    }
}