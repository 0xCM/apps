//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static CsPatterns;

    partial class AsmModelGen
    {
        const string InstructionContainerName = "AsmInstructions";

        [Op]
        void EmitInstructionTypes(ReadOnlySpan<string> monics, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.AppendLine(string.Format(NamespaceDeclPattern, TargetNamespaceName));
            buffer.AppendLine(Open);
            margin += Indent;
            buffer.IndentLine(margin, UsingCompilerServices);
            buffer.IndentLine(margin, UsingRoot);
            buffer.AppendLine();

            buffer.IndentLine(margin, PublicReadonlyStruct(InstructionContainerName));
            buffer.IndentLine(margin, Open);
            margin += Indent;
            var model = InstructionModel.Empty;
            var count = monics.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var monic = ref skip(monics,i);
                model = new AsmMnemonic(monic);
                model.RenderType(margin, buffer);
            }

            margin -= Indent;
            buffer.IndentLine(margin, Close);

            margin -= Indent;
            buffer.IndentLine(margin, Close);

            using var writer = dst.Writer();
            writer.Write(CgRules.FileHeader());
            writer.Write(buffer.Emit());

            Wf.EmittedFile(flow, monics.Length);
        }
    }
}