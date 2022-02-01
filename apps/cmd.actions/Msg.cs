//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    partial struct Msg
    {

        public static MsgPattern<ApiHostUri> ParsingHostMembers => "Parsing {0} members";

        public static MsgPattern<Count,ApiHostUri> ParsedHostMembers => "Parsed {0} {1} members";

        public static MsgPattern<Count> ParsingHosts => "Parsing {0} hosts";


        public static MsgPattern<Count,Count> ParsedHosts => "Parsed {0} members from {1} hosts";

        public static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        public static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";

    }
}