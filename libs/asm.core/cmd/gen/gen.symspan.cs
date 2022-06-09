//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/symspan")]
        void GenSymSpan()
            => CsLang.EmitSymSpan<AsciLetterLoSym>(AppDb.CgStage().Path("symspan", FileKind.Cs));
    }
}
