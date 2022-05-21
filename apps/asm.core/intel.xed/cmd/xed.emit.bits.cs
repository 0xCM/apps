//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/emit/bits")]
        void EmitRuleBits()
        {
            var bitfield = RuleBits.create();
            var dst = text.emitter();
            dst.AppendLine(bitfield.RowHeader());
            bitfield.Format(CellTables, dst);
            AppSvc.FileEmit(dst.Emit(), 23, XedPaths.RuleTargets().Path("xed.rules.bits", FileKind.Csv));
        }

        [CmdOp("xed/emit/instbits")]
        void EmitInstBits()
        {
            var calcs = InstFieldBits.Calcs;

            Write(calcs.Description().Format());
            Write(calcs.Descriptor());
            Write(calcs.Model().Format());
            // Write(calcs.Def);

            //Write($"{bp} | {bp.Size.Packed} | {bp.Size.Native}");
        }
    }
}