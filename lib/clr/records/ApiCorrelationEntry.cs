//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCorrelationEntry : IRecord<ApiCorrelationEntry>
    {
        public const string TableId = "api.correlations";

        public Seq16x2 Key;

        public MemoryAddress CaptureAddress;

        public MemoryAddress RuntimeAddress;

        public OpUri Id;
    }
}