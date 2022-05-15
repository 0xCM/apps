//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISTHost : ISTRes
    {
        STRes Res {get;}

        uint ISTRes.EntryCount
             => Res.EntryCount;

        uint ISTRes.CharCount
            => Res.CharCount;

        MemoryAddress ISTRes.CharBase
            => Res.CharBase;

        MemoryAddress ISTRes.OffsetBase
            => Res.CharCount;

        MemoryStrings ISTRes.Strings
            => Res.Strings;
    }

    [Free]
    public interface ISTHost<K> : ISTHost, ISTRes<K>
        where K : unmanaged
    {
        new STRes<K> Res {get;}

        STRes ISTHost.Res
            => Res;
    }

    [Free]
    public interface ISTHost<H,K> : ISTHost<K>
        where K : unmanaged
        where H : unmanaged, ISTHost<H,K>
    {

    }
}
