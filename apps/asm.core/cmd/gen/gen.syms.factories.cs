//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/syms/factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var name = "AsmRegTokens";
            var dst = AppDb.CgStage().Path(name, FileKind.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            CsLang.GenSymFactories("Z0.Asm", name, src, dst);
            return true;
        }

        [CmdOp("gen/symspan")]
        Outcome EmitSymSpan(CmdArgs srgs)
        {
            var result = Outcome.Success;
            CsLang.EmitSymSpan<AsciLetterLoSym>(AppDb.CgStage().Path("symspan", FileKind.Cs));
            // var dst = ProjectDb.Logs() + FS.folder("cs") + FS.file("symspan", FS.Cs);
            // var emitting = EmittingFile(dst);
            // using var writer = dst.AsciWriter();
            // EmitSymSpan<AsciLetterLoSym>("AsciLetterLoSym", writer);
            // EmittedFile(emitting, 1);
            return result;
        }

    }
}