//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public void EmitInstGroups(Index<InstGroup> src)
        {
            const string RenderPattern = "{0,-12} | {1,-18} | {2,-8} | {3,-8} | {4,-6} | {5,-6} | {6,-6} | {7,-26} | {8}";
            var counter = 0u;
            var dst = text.buffer();
            var k=0u;
            dst.AppendLineFormat(RenderPattern, "PatternId", "Instruction", "Mod", "Lock", "Mode", "RexW", "Index", "OpCode", "Form");
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
                        member.PatternId,
                        member.Class,
                        member.Mod,
                        member.Lock,
                        member.Mode,
                        member.RexW,
                        member.Index,
                        member.OpCode,
                        member.InstForm
                        );

                    counter++;
                }

                dst.AppendLine();
                dst.AppendLine(RP.PageBreak160);
                dst.AppendLine();
            }
            FileEmit(dst.Emit(), counter, XedPaths.Targets() + FS.file("xed.inst.groups", FS.Csv), TextEncodingKind.Asci);
        }
    }
}