//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    partial struct Msg
    {
        public static MsgPattern<ApiHostUri,Count> RunningHostEmissionWorkflow => "Running {0} emission workflow for {1} members";

        public static MsgPattern<Count,ApiHostUri> ParsedExtractBlocks => "Parsed {0} {1} extract blocks";

        public static MsgPattern<ApiHostUri> EmittingHostRoutines => "Emitting {0} routines";

        public static MsgPattern<Count,ApiHostUri,FS.FileUri> EmittedHostRoutines => "Emitted {0} {1} routines to {2}";

        public static MsgPattern<ApiHostUri> CreatingApiStatements => "Creating {0} host api statements";

        public static MsgPattern<ApiHostUri,Count> CreatedApiStatements => "Created {0} {1} host api statement";

        public static MsgPattern<Count,Count,FS.FileUri> ParsedStatements => "Parsed {0} full rows and {1} partial rows from {2}";

        public static MsgPattern<Count> DecodingParts => "Decoding {0} parts";

        public static MsgPattern<Count,Count> DecodedMachine => "Decoded {0} routines from {1} parts";

        public static MsgPattern<FS.FileUri> LoadingStatements
            => "Loading statements from {0}";

        public static MsgPattern<Count,FS.FileUri> LoadedStatments
            => "Loading {0} statements from {1}";

        public static MsgPattern<Count,FS.FileUri> ProcessingStatments
            => "Processing {0} statements from {1}";

        public static MsgPattern<Count,FS.FileUri> ProcessedStatements
            => "Processed {0} statements from {1}";

        public static MsgPattern<Count> CreatingStatements => "Creating statements for {0} routines";

        public static MsgPattern<FS.FolderPath> CapturingRoutines => "Capturing routines from {0}";

        public static MsgPattern<Count,Count> CapturedRoutines => "Captured {0} routines from {1} hosts";

        public static MsgPattern<Count, DelimitedIndex<PartId>> RunningMachine => "Executing machine workflow for {0} parts: {1}";

        public static MsgPattern<Count, DelimitedIndex<PartId>> RanMachine => "Executed machine workflow for {0} parts: {1}";
    }
}