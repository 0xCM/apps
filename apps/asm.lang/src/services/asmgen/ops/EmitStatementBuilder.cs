//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using T = AsmGenTarget;

    partial class AsmModelGen
    {
        const string ClassDeclPattern = "public class {0}";

        public void EmitStatementBuilder(ReadOnlySpan<string> src, FS.FilePath dst)
        {
            var buffer = text.buffer();
            var margin = 0u;
            buffer.AppendLine(NamespaceDecl());
            buffer.AppendLine(Open);
            margin += Indent;
            buffer.IndentLine(margin, UsingCompilerServices);
            buffer.IndentLine(margin, UsingRoot);
            buffer.IndentLine(margin, string.Format(UsingTypePattern, TargetIdentifier(T.InstructionTypes)));
            buffer.AppendLine();

            buffer.IndentLine(margin, string.Format(ClassDeclPattern,TargetIdentifier(T.StatementBuilder)));
            buffer.IndentLine(margin, Open);
            margin += Indent;

            EmitStatementFactories(margin, src, buffer);

            margin -= Indent;
            buffer.IndentLine(margin, Close);

            margin -= Indent;
            buffer.IndentLine(margin, Close);

            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            writer.Write(CgRules.FileHeader());
            writer.Write(buffer.Emit());
            Wf.EmittedFile(flow,src.Length);
        }
    }
}