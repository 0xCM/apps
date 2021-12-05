//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct UriCode : IRecord<UriCode>
    {
        public const string TableId = "api.code";

        public const byte FieldCount = 3;

        public OpUri Uri;

        public MemoryAddress Address;

        public BinaryCode Data;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{80,16,80};
    }
}