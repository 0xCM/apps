//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelXed
    {
        public XedInstructions EmitInstructions()
        {
            var src =  XedSources + FS.file("xed-tables", FS.Txt);
            var result = InstTableParser.Parse(src, out var inst);
            if(result)
            {
                TableEmit(inst.Descriptions, XedInstructions.InstInfo.RenderWidths, ProjectDb.TablePath<XedInstructions.InstInfo>("xed"));
                TableEmit(inst.Operands, XedInstructions.InstOperandInfo.RenderWidths,  ProjectDb.TablePath<XedInstructions.InstOperandInfo>("xed"));
                return inst;
            }
            else
            {
                Error(result.Message);
                return XedInstructions.Empty;
            }
        }
    }
}