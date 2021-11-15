//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public ref struct ApiCallData
    {
        [MethodImpl(Inline)]
        public static ApiCallData serialize<T>(in T call)
            where T : unmanaged, IApiCall<T>
                => new ApiCallData(call.Api, slice(bytes(call), 16));

        public ApiKey Api {get;}

        public ReadOnlySpan<byte> Bytes {get;}

        [MethodImpl(Inline)]
        public ApiCallData(ApiKey api, ReadOnlySpan<byte> src)
        {
            Bytes = src;
            Api = api;
        }
    }
}