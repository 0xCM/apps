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
    using static XedPatterns;
    using static XedFields;

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        public ref struct FieldEmitter
        {
            Func<FileRef,FS.FilePath> Target;

            readonly Action<string,Count,FS.FilePath> Channel;

            readonly Span<FieldKind> Members;

            readonly Fields Fields;

            readonly HashSet<FieldKind> Exclusions;

            readonly ITextBuffer Buffer;

            readonly FieldRender Render;

            public FieldEmitter(Func<FileRef,FS.FilePath> target, Action<string,Count,FS.FilePath> channel, ByteBlock128 members = default, PageBlock2 fields = default)
            {
                Target = target;
                Channel = channel;
                Members = recover<FieldKind>(members.Bytes);
                Fields = new Fields(fields);
                Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT);
                State = RuleState.Empty;
                XDis = XDis.Empty;
                Buffer = text.buffer();
                Render = XedFields.render();
                Doc = DisasmDetailDoc.Empty;
            }

            RuleState State;

            XDis XDis;

            //EncodingExtract Encoding;

            DisasmDetailDoc Doc;

            const string RenderPattern = DisasmRender.Columns;

            public void Dispose()
            {

            }

            void Clear()
            {
                State = RuleState.Empty;
                XDis = XDis.Empty;
                Fields.Clear();
            }

            public void Emit(DisasmDetailDoc doc)
            {
                Doc = doc;

                ref readonly var file = ref Doc.File;
                for(var i=0u; i<file.LineCount; i++)
                {
                    Clear();

                    ref readonly var detail = ref Doc[i].Detail;
                    ref readonly var ops = ref detail.Ops;
                    ref readonly var form = ref detail.InstForm;
                    ref readonly var block = ref Doc[i].Block;
                    ref readonly var lines = ref block.Lines;
                    ref readonly var summary = ref block.Summary;
                    ref readonly var asmhex = ref summary.Encoded;
                    ref readonly var asmtxt = ref summary.Asm;
                    ref readonly var ip = ref summary.IP;

                    DisasmParse.parse(lines.XDis.Content, out XDis).Require();

                    XedDisasm.fields(lines, kvp(lines), Fields, false);
                    var count = Fields.Members(Members);
                    var kinds = slice(Members, 0, count);
                    XedState.update(Fields, ref State);
                    var encoding = XedState.encoding(State, asmhex);

                    //AppendHeader(i);
                    //ref var field = ref Fields[K.INVALID];

                    //var ocindex = XedState.ocindex(State);
                    Buffer.AppendLine(RP.PageBreak240);
                    Buffer.AppendLine(lines.Format());
                    Buffer.AppendLine(RP.PageBreak100);
                    Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Asm), XDis.Asm);
                    Buffer.AppendLineFormat(RenderPattern, "Instruction", ((InstClass)Fields[K.ICLASS]).Format());
                    Buffer.AppendLineFormat(RenderPattern, "Form", form);
                    Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Category), XDis.Category);
                    Buffer.AppendLineFormat(RenderPattern, nameof(XDis.Extension), XDis.Extension);
                    Buffer.AppendLineFormat(RenderPattern, nameof(encoding.Offsets), encoding.Offsets.Format());
                    Buffer.AppendLineFormat(RenderPattern, nameof(encoding.OpCode), XedRender.format(encoding.OpCode));
                    if(encoding.ModRm.IsNonZero)
                        Buffer.AppendLineFormat(RenderPattern, nameof(encoding.ModRm), encoding.ModRm);
                    if(encoding.Sib.IsNonZero)
                        Buffer.AppendLineFormat(RenderPattern, nameof(encoding.Sib), encoding.Sib);
                    if(encoding.Imm.IsNonZero)
                        Buffer.AppendLineFormat(RenderPattern, nameof(encoding.Imm), encoding.Imm);
                    if(encoding.Imm1.IsNonZero)
                        Buffer.AppendLineFormat(RenderPattern, nameof(encoding.Imm), encoding.Imm1);
                    if(encoding.Disp.IsNonZero)
                        Buffer.AppendLineFormat(RenderPattern, nameof(encoding.Disp), encoding.Disp);

                    Buffer.AppendLine(RP.PageBreak100);
                    for(var k=0; k<count; k++)
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