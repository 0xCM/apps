//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    [ApiHost]
    public sealed partial class IntelXed : AppService<IntelXed>
    {
        bool Verbose {get;} = false;

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        public XedPaths XedPaths => Service(Wf.XedPaths);

        public XedPatterns Patterns => Service(Wf.XedPatterns);

        AppDb AppDb => Service(Wf.AppDb);

        public XedRules Rules => Service(Wf.XedRules);

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        static Index<BroadcastDef> _BroadcastDefs;

        static IntelXed()
        {
            _BroadcastDefs = bcastdefs();
        }
   }
}