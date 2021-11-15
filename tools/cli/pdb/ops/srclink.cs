//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.DiaSymReader;

    using static Root;
    using static PdbModel;
    using static core;

    partial struct PdbServices
    {
        [Op]
        internal static unsafe Outcome srclink(ISymUnmanagedReader5 src, out Span<byte> dst)
        {
            dst = default;
            try
            {
                HResult hr = src.GetSourceServerData(out var pData, out var size);
                if(hr)
                {
                    read(pData, size, out dst);
                    return true;
                }
                else
                {
                    size = 0;
                    return (false, hr.Format());
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }
    }
}