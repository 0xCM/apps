//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmModelGen
    {
        void EmitInstructionContracts(FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var buffer = text.buffer();
            RenderInstructionContracts(0,buffer);

            using var writer = dst.Writer();
            writer.Write(CgRules.FileHeader());
            writer.Write(buffer.Emit());

            Wf.EmittedFile(flow,1);
        }

        void RenderInstructionContracts(uint margin, ITextBuffer dst)
        {
            var target = TargetIdentifier(AsmGenTarget.InstructionContracts);
            var content = InstructionContractPattern.Replace(RP.embrace("TargetName"), target);
            dst.AppendLine(content);
        }
    }
}