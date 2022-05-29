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
    }
}