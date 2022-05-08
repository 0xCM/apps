//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("api/emit/bitmasks")]
        Outcome EmitBitMasks(CmdArgs args)
        {
            var emitted = ApiBitMasks.Emit();
            return true;
        }

        [CmdOp("api/emit/types")]
        Outcome EmitDataTypes(CmdArgs args)
        {
            TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.ProjectDb().Api() + Tables.filename<DataTypeRecord>());
           return true;
        }

        [CmdOp("api/emit/markdown")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            ApiComments.EmitMarkdownDocs(array(nameof(vpack),nameof(vmask)));
            return true;
        }

        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            AsmDocs.Emit();
            return true;
        }
    }
}