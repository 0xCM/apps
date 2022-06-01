//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    struct Msg
    {
        public static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        public static MsgPattern<ApiHostUri> ParsingHostMembers => "Parsing {0} members";

        public static MsgPattern<Count,ApiHostUri> ParsedHostMembers => "Parsed {0} {1} members";

        public static MsgPattern<Count> ParsingHosts => "Parsing {0} hosts";

        public static MsgPattern<Count,Count> ParsedHosts => "Parsed {0} members from {1} hosts";

        public static RenderPattern<Count,FS.FilePath> LoadedForms => "Loaded {0} forms from {1}";

        public static MsgPattern<string,string> ParseFailure => "Parsing {0} from '{1}' failed";

        public static MsgPattern CollectingEntryPoints => "Collecting entry points";

        public static MsgPattern<Count> CollectedEntryPoints => "Collecting {0} entry points";

        public static MsgPattern<string> NotFound => "'{0}' not found";


        public static MsgPattern<ApiHostUri> ExtractingHost => "Extracting {0} members";

        public static MsgPattern<Count,ApiHostUri> ExtractedHost => "Extracted {0} members from {1}";

        const NumericKind Closure = Root.UnsignedInts;
    }
}