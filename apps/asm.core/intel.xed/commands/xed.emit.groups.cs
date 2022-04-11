//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/groups")]
        Outcome EmitInstGroups(CmdArgs args)
        {
            const string RenderPattern = "{0,-12} | {1,-18} | {2,-8} | {3,-8} | {4,-6} | {5,-6} | {6,-6} | {7,-26} | {8}";
            var counter = 0u;
            var groups = Xed.Rules.CalcInstGroups();
            var classes = groups.Keys;
            var dst = text.buffer();
            var k=0u;
            dst.AppendLineFormat(RenderPattern, "PatternId", "Instruction", "Mod", "Lock", "Mode", "RexW", "Index", "OpCode", "Form");
            for(var i=0; i<classes.Length; i++)
            {
                ref readonly var @class = ref skip(classes,i);
                var group = groups[@class];
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
                        $"{member.OpCode.Symbol}[{member.OpCode.Selector}]:{member.OpCode.Value}",
                        $"{member.InstForm}"
                        );
                    counter++;
                }

                dst.AppendLine();
                dst.AppendLine(RP.PageBreak160);
                dst.AppendLine();
            }
            FileEmit(dst.Emit(), counter, XedPaths.Targets() + FS.file("xed.inst.groups", FS.Csv), TextEncodingKind.Asci);
            return true;
        }
    }
}