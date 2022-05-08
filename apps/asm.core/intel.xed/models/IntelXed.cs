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
        XedRuntime Xed;


        bool Verbose {get;} = false;

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        XedPaths XedPaths => Xed.Paths;

        public IntelXed With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        static IntelXed()
        {

        }
   }
}