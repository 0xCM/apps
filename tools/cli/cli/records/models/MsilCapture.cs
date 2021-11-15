//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MsilCapture : IRecord<MsilCapture>
    {
        public const string TableId = "cil.data";

        public const byte FieldCount = 4;

        public CliToken Token;

        public MemoryAddress BaseAddress;

        public OpUri Uri;

        public BinaryCode Encoded;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,80,20};
    }
}