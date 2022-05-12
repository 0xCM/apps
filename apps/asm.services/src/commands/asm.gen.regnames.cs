//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.IO;

    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("gen/symspan")]
        Outcome EmitSymSpan(CmdArgs srgs)
        {
            var result = Outcome.Success;
            CsLang.EmitSymSpan<AsciLetterLoSym>(AppDb.CgStage().Path("symspan", FileKind.Cs));
            return result;
        }
    }
}