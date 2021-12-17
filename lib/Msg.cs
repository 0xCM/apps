//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Msg
    {
        public static MsgPattern<FS.FileUri> LoadingSpanAccessors => "Loading respack accessors from {0}";

        public static MsgPattern<Count,FS.FileUri> LoadedSpanAccessors => "Loaded {0} respack accessors from {1}";

        public static MsgPattern<Count> LoadingHexFileBlocks => "Loading hex blocks from {0} files";

        public static MsgPattern<Count> LoadedHexBlocks => "Loaded {0} hex blocks";

        public static MsgPattern<Count> ProcessingApiHexFiles => "Processing {0} api hex files";

        public static MsgPattern<Count> AccumulatedDescriptors => "Accumulated {0} descriptors";

        public static MsgPattern<FS.FileUri,TextEncodingKind,Count> SplittingFile
            => "Splitting {0} into {1}-encoded parts with a maximum of {2} lines each";

        public static MsgPattern<Count,FS.FileUri,Count> FinishedFileSplit
            => "Partitioned {0} lines from {1} into {2} parts";
    }
}
