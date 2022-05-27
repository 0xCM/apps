//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiRuntimeMember
    {
        public const string TableId ="api.member";

        public MemoryAddress Address;

        public OpUri Uri;

        public MethodDisplaySig DisplaySig;

        public ApiMsil Msil;
    }
}