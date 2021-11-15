//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    readonly partial struct Msg
    {
        public static MsgPattern<Count,Count,string> FieldCountMismatch => "{0} fields were found while {1} were expected: {2}";

        public static MsgPattern<ApiHostUri,uint,uint> IndexedHost => "{0,-30} | {1}/{2}";

        public static MsgPattern<uint> IndexingHosts => "Indexing {0} hosts";

        public static MsgPattern<ApiHostUri> CreatingHostCatalog => "Creating {0} catalog";

        public static MsgPattern<ApiHostUri,Count> CreatedHostCatalog => "Created {0} catalog with {1} members";

        public static MsgPattern<ApiHostUri,FS.FilePath> HostFileMissing => "The {0} file {1} does not exist";

        public static RenderPattern<Count> IndexingPartFiles => "Indexing {0} partfile datasets";

        public static RenderPattern<FS.FilePath> IndexingCodeBlocks => "Indexing code blocks from {0}";

        public static RenderPattern<Count,FS.FilePath> AbsorbedCodeBlocks => "Absorbed {0} code blocks from {1}";

        public static RenderPattern<OpUri> Unbased => "The block {0} has no base addressed";

        public static RenderPattern<OpUri> DuplicateUri => "The uri {0} has been duplicated";

        public static string Unparsed<T>(T src) => unparsed<T>().Format(src);

        static RenderPattern<T> unparsed<T>() => "Unable to parse {0}";

        public static MsgPattern<Count> CorrelatingParts => "Correlating {0} part catalogs";

        public static MsgPattern<string> CorrelatingOperations => "Correlating {0} operations";

        public static MsgPattern<Count> JittingParts => "Jitting {0} parts";

        public static MsgPattern<PartId> JittingPart => "Jitting {0} members";

        public static MsgPattern<Count,PartId> JittedPart => "Jitted {0} {1} members";

        public static MsgPattern<dynamic,dynamic> JittedParts => "Jitted {0} members from {1} parts";

        public static MsgPattern<Count> LocatingSegments => "Locating segments for {0} methods";

        public static MsgPattern<Count,Count> LocatedSegments => "Computed {0} segment entries for {0} methods";

        public static MsgPattern<Address16> SegSelectorNotFound => "Selector {0} not found";

        public static MsgPattern<FS.FileUri> LoadingApiCatalog => "Loading api catalog from {0}";

        public static MsgPattern<Count,FS.FileUri> LoadedApiCatalog => "Loaded {0} catalog entries from {1}";
    }
}