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
        void EmitBitMasks()
            => ApiBitMasks.Emit();

        void EmitDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.ProjectDb().Api() + Tables.filename<DataTypeRecord>());

        void EmitApiComments()
            => ApiComments.EmitMarkdownDocs(new string[]{
                nameof(vpack),
                nameof(vmask),
                nameof(cpu),
                nameof(gcpu),
                nameof(BitMasks),
                nameof(BitMaskLiterals),
                });

        void EmitAsmDocs()
            => AsmDocs.Emit();

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            EmitBitMasks();
            EmitDataTypes();
            EmitApiComments();
            EmitAsmDocs();
            return true;
        }

        [CmdOp("api/emit/bitmasks")]
        Outcome EmitBitMasks(CmdArgs args)
        {
            EmitBitMasks();
            return true;
        }

        [CmdOp("api/emit/types")]
        Outcome EmitDataTypes(CmdArgs args)
        {
            EmitDataTypes();
           return true;
        }

        [CmdOp("api/emit/comments")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            EmitApiComments();
            return true;
        }

        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitAsmDocs();
            return true;
        }
    }
}