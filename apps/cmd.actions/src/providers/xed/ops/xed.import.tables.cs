//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    partial class XedCmdProvider
    {
        [CmdOp("xed/import/tables")]
        Outcome ImportTables(CmdArgs args)
        {
            var table = Xed.ParseInstructions();

            TableEmit(table.Descriptions, XedInstructions.InstInfo.RenderWidths, ProjectDb.TablePath<XedInstructions.InstInfo>("xed"));
            TableEmit(table.Operands, XedInstructions.InstOperand.RenderWidths,  ProjectDb.TablePath<XedInstructions.InstOperand>("xed"));

            return true;
        }
    }
}