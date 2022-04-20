//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedFields;

    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        public ref struct FieldEmitter
        {
            readonly HashSet<FieldKind> Exclusions;

            readonly FieldRender Render;

            readonly FS.FilePath Path;

            public FieldEmitter(FS.FilePath dst)
            {
                Path = dst;
                Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT);
                Render = XedFields.render();
            }

            const string RenderPattern = DisasmRender.Columns;

            static void AppendHeader(in FieldBuffer src, ITextBuffer dst)
            {
                dst.AppendLine(RP.PageBreak240);
                dst.AppendLine(src.Lines.Format());
                dst.AppendLine(RP.PageBreak100);
                dst.AppendLineFormat(RenderPattern, nameof(src.AsmInfo.Asm), src.AsmInfo.Asm);
                dst.AppendLineFormat(RenderPattern, nameof(src.Props.Instruction), src.Props.Instruction);
                dst.AppendLineFormat(RenderPattern, nameof(src.Props.Form), src.Props.Form);
                dst.AppendLineFormat(RenderPattern, nameof(src.AsmInfo.Category), src.AsmInfo.Category);
                dst.AppendLineFormat(RenderPattern, nameof(src.AsmInfo.Extension), src.AsmInfo.Extension);
                dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.Offsets), src.Encoding.Offsets.Format());
                dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.OpCode), XedRender.format(src.Encoding.OpCode));
                if(src.Encoding.ModRm.IsNonZero)
                    dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.ModRm), src.Encoding.ModRm);
                if(src.Encoding.Sib.IsNonZero)
                    dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.Sib), src.Encoding.Sib);
                if(src.Encoding.Imm.IsNonZero)
                    dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.Imm), src.Encoding.Imm);
                if(src.Encoding.Imm1.IsNonZero)
                    dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.Imm), src.Encoding.Imm1);
                if(src.Encoding.Disp.IsNonZero)
                    dst.AppendLineFormat(RenderPattern, nameof(src.Encoding.Disp), src.Encoding.Disp);
                dst.AppendLine(RP.PageBreak100);
            }

            public uint EmitFields(Detail doc)
            {
                var buffer = FieldBuffer.init();
                var dst = text.buffer();
                ref readonly var data = ref doc.DataFile;
                var counter = 0u;
                for(var i=0u; i<data.LineCount; i++)
                {
                    ref readonly var block = ref doc[i];
                    fields(block, ref buffer);

                    ref readonly var ops = ref block.DetailRow.Ops;
                    var kinds = buffer.FieldSelection;
                    AppendHeader(buffer, dst);
                    for(var k=0; k<kinds.Length; k++)
                    {
                        ref readonly var kind = ref skip(kinds,k);
                        if(Exclusions.Contains(kind))
                            continue;

                        dst.AppendLineFormat(RenderPattern, kind, Render[kind](buffer.Fields[kind]));
                        counter++;
                    }

                    DisasmRender.RenderOps(ops, dst);
                    dst.AppendLine();
                }

                using var emitter = Path.AsciEmitter();
                emitter.Write(dst.Emit());
                return counter;
            }
        }
    }
}