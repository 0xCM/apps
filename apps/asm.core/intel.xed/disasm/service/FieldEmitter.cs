//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDisasm;
    using static XedFields;
    using static XedModels;

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        public ref struct FieldEmitter
        {
            Func<FileRef,FS.FilePath> Target;

            readonly Action<string,Count,FS.FilePath> Channel;

            readonly HashSet<FieldKind> Exclusions;

            readonly ITextBuffer Buffer;

            readonly FieldRender Render;

            public FieldEmitter(Func<FileRef,FS.FilePath> target, Action<string,Count,FS.FilePath> channel)
            {
                Target = target;
                Channel = channel;
                Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT);
                Buffer = text.buffer();
                Render = XedFields.render();
                State = RuleState.Empty;
                Fields = XedFields.fields();
                XDis = XDis.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
            }

            RuleState State;

            readonly Fields Fields;

            XDis XDis;

            DisasmProps Props;

            EncodingExtract Encoding;

            const string RenderPattern = DisasmRender.Columns;

            public void Dispose()
            {

            }

            void Clear()
            {
                State = RuleState.Empty;
                XDis = XDis.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
                Fields.Clear();
            }

            ReadOnlySpan<FieldKind> Load(in DetailBlock src)
            {
                ref readonly var block = ref src.Block;
                ref readonly var lines = ref block.Lines;
                ref readonly var summary = ref block.Summary;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;
                DisasmParse.parse(lines.XDis.Content, out XDis).Require();
                DisasmParse.parse(lines, out Props);
                XedDisasm.fields(lines, Props, Fields, false);

                var kinds = Fields.MemberKinds();
                XedState.Edit.fields(Fields, kinds, ref State);
                Encoding = XedState.Code.encoding(State, asmhex);
                return kinds;
            }

            void AppendHeader(in DisasmLineBlock lines, InstForm form)
            {
                Buffer.AppendLine(RP.PageBreak240);
                Buffer.AppendLine(lines.Format());
                Buffer.AppendLine(RP.PageBreak100);
                Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Asm), XDis.Asm);
                Buffer.AppendLineFormat(RenderPattern, nameof(Props.Instruction), Props.Instruction);
                Buffer.AppendLineFormat(RenderPattern, nameof(Props.Form), Props.Form);
                Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Category), XDis.Category);
                Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Extension), XDis.Extension);
                Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.Offsets), Encoding.Offsets.Format());
                Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.OpCode), XedRender.format(Encoding.OpCode));
                if(Encoding.ModRm.IsNonZero)
                    Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.ModRm), Encoding.ModRm);
                if(Encoding.Sib.IsNonZero)
                    Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.Sib), Encoding.Sib);
                if(Encoding.Imm.IsNonZero)
                    Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.Imm), Encoding.Imm);
                if(Encoding.Imm1.IsNonZero)
                    Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.Imm), Encoding.Imm1);
                if(Encoding.Disp.IsNonZero)
                    Buffer.AppendLineFormat(RenderPattern, nameof(Encoding.Disp), Encoding.Disp);

                Buffer.AppendLine(RP.PageBreak100);
            }

            public void Emit(DisasmDetailDoc doc)
            {
                ref readonly var file = ref doc.File;
                for(var i=0u; i<file.LineCount; i++)
                {
                    Clear();

                    ref readonly var ops = ref doc[i].Detail.Ops;
                    ref readonly var form = ref doc[i].Detail.InstForm;
                    ref readonly var lines = ref doc[i].Block.Lines;
                    var kinds = Load(doc[i]);

                    AppendHeader(lines, form);
                    for(var k=0; k<kinds.Length; k++)
                    {
                        ref readonly var kind = ref skip(kinds,k);
                        if(Exclusions.Contains(kind))
                            continue;

                        Buffer.AppendLineFormat(RenderPattern, kind, Render[kind](Fields[kind]));
                    }

                    DisasmRender.RenderOps(ops,Buffer);
                    Buffer.AppendLine();
                }

                Channel(Buffer.Emit(), file.LineCount, Target(file.Source));
            }
        }
    }
}