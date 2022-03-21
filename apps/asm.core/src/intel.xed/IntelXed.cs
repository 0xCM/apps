//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;
    using static XedRules;
    using static core;

    [ApiHost]
    public sealed partial class IntelXed : AppService<IntelXed>
    {
        bool Verbose {get;} = false;

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        public XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        public XedRules Rules => Service(Wf.XedRules);

        public XedRuleTables RuleTables => Rules.RuleTables;

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        static Index<AsmBroadcastDef> _BroadcastDefs;

        static IntelXed()
        {
            _BroadcastDefs = bcastdefs();
        }
   }
}