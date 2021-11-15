//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MethodSegment : IRecord<MethodSegment>
    {
        public const string TableId = "method.segments";

        public const byte FieldCount = 8;

        public uint MethodIndex;

        public MemoryAddress EntryPoint;

        public uint SegIndex;

        public Address16 SegSelector;

        public ByteSize SegSize;

        public MemoryAddress SegStart;

        public MemoryAddress SegEnd;

        public utf8 Uri;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,16,16,16,16,80};
    }

}