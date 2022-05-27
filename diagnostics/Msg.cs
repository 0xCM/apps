//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;

        public static MsgPattern<ApiHostUri> ExtractingHost => "Extracting {0} members";

        public static MsgPattern<Count,ApiHostUri> ExtractedHost => "Extracted {0} members from {1}";

        public static MsgPattern<MemoryAddress> TraversingSegments => "Traversing memory segments above the process base address {0}";

        public static MsgPattern<ByteSize,Count> TraversedSegments => "Traversed {0} bytes from {1} accessible regions";

        public static MsgPattern<ProcessMemoryRegion> TraversingRegion => "Traversing {0}";

        public static MsgPattern<MemoryRange> TraversingRange => "Traversing {0}";

        public static MsgPattern<MemoryRange> TraversedRange => "Traversed {0}";

        public static MsgPattern<ByteSize,ProcessMemoryRegion> TraversedRegion => "Traversed {0} bytes from {0}";

    }
}