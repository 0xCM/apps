//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

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