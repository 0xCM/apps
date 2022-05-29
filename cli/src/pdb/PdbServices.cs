//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct PdbServices
    {
        [Op]
        public static unsafe Outcome srclink(ISymUnmanagedReader5 src, out Span<byte> dst)
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

         /// <summary>
        /// Retrieves symbol server information
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dst"></param>
        /// <remarks>
        /// Adapted from https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter/Utilities/SymReaderHelpers.cs
        /// </remarks>
        public unsafe static Outcome symserver(ISymUnmanagedReader reader, out Span<byte> dst)
        {
            dst = default;
            if (!(reader is ISymUnmanagedSourceServerModule srcsrv))
                return (false, string.Format("{0} does not support the required iterface", reader.GetType()));

            var pData = default(byte*);
            try
            {
                HResult result = srcsrv.GetSourceServerData(out var size, out pData);
                if(result)
                {
                    read(pData, size, out dst);
                    return true;
                }
                else
                    return (false,result.Format());
            }
            catch(Exception e)
            {
                return e;
            }
            finally
            {
                if (pData != null)
                    Marshal.FreeCoTaskMem((IntPtr)pData);
            }
        }
    }
}