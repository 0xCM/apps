//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    [ApiHost]
    public sealed partial class IntelXed : AppService<IntelXed>
    {
        bool Verbose {get;} = false;

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        public XedPaths XedPaths => Service(Wf.XedPaths);

        public XedRules Rules => Service(Wf.XedRules);

        public XedRegMap CalcRegMap()
            => Data(nameof(CalcRegMap), () => regmap());

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";
   }
}