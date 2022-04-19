//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiRuntimeMember : IRecord<ApiRuntimeMember>
    {
        public const string TableId ="api.member";

        public MemoryAddress Address;

        public OpUri Uri;

        public MethodDisplaySig DisplaySig;

        public ApiMsil Msil;
    }
}