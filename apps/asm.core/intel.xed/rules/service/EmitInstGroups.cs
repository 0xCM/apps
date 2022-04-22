//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public void EmitGroupReports(Index<InstGroup> src)
            => core.iter(XedRules.seq(src), kvp => EmitGroupReport(kvp.Key, kvp.Value), PllExec);

        void EmitGroupReport(OpCodeClass @class, Index<InstGroupSeq> src)
            => TableEmit(resequence(src).View, InstGroupSeq.RenderWidths, XedPaths.Table<InstGroupSeq>(@class.ToString().ToLower()));

        public void Emit(Index<InstGroup> src)
        {
            EmitGroupReports(src);

            const string RenderPattern = "{0,-8} | {1,-12} | {2,-18} | {3,-8} | {4,-8} | {5,-6} | {6,-6} | {7,-6} | {8,-6} | {9,-26} | {10,-22} | {11}";
            var counter = 0u;
            var dst = text.buffer();
            var k=0u;
            dst.AppendLineFormat(RenderPattern, "Seq", "PatternId", "Instruction", "Mod", "Lock", "Mode", "RexW", "Rep", "Index", "OpCode", "OpCodeBytes", "Form");
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var group = ref src[i];
                var opcode = XedOpCode.Empty;
                foreach(var member in group.Members)
                {
                    if(opcode.IsEmpty)
                        opcode = member.OpCode;

                    if(opcode != member.OpCode)
                    {
                        dst.AppendLine();
                        opcode = member.OpCode;
                    }

                    dst.AppendLineFormat(RenderPattern,
                        k++,
                        member.PatternId,
                        member.Class,
                        member.Mod,
                        member.Lock,
                        member.Mode,
                        member.RexW,
                        member.Rep,
                        member.Index,
                        member.OpCode,
                        member.OpCode.Value,
                        member.InstForm
                        );

                    counter++;
                }

                dst.AppendLine();
            }
            FileEmit(dst.Emit(), counter, XedPaths.Targets() + FS.file("xed.inst.groups", FS.Csv), TextEncodingKind.Asci);
        }
    }
}