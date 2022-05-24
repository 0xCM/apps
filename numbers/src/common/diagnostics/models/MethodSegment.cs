//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MethodSegment : IRecord<MethodSegment>
    {
        public const string TableId = "method.segments";

        public const byte FieldCount = 8;

        [Render(16)]
        public uint MethodIndex;

        [Render(16)]
        public MemoryAddress EntryPoint;

        [Render(16)]
        public uint SegIndex;

        [Render(16)]
        public Address16 SegSelector;

        [Render(16)]
        public ByteSize SegSize;

        [Render(16)]
        public MemoryAddress SegStart;

        [Render(16)]
        public MemoryAddress SegEnd;

        [Render(1)]
        public utf8 Uri;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,16,16,16,16,80};
    }
}