//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IRecordEmitter
    {
        Outcome Emit<T>(in T src, StreamWriter dst)
            where T : struct;

        Outcome Emit<T>(ReadOnlySpan<T> src, StreamWriter dst, bool header = true)
            where T : struct;

        Outcome Emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter dst, bool header = true)
            where T : struct;
    }
}