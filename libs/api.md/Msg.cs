//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;

        public static MsgPattern<Count,Count,string> FieldCountMismatch => "{0} fields were found while {1} were expected: {2}";

        public static MsgPattern<Count> CorrelatingParts => "Correlating {0} part catalogs";

        public static MsgPattern<string> CorrelatingOperations => "Correlating {0} operations";

        public static MsgPattern<FS.FileUri> LoadingApiCatalog => "Loading api catalog from {0}";

        public static MsgPattern<Count,FS.FileUri> LoadedApiCatalog => "Loaded {0} catalog entries from {1}";
    }
}