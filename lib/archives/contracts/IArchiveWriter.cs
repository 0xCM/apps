//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IArchiveWriter : IDisposable
    {

    }

    [Free]
    public interface IArchiveWriter<H> : IArchiveWriter
        where H : struct, IArchiveWriter<H>
    {

    }
}