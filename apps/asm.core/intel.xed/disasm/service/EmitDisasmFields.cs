//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;
    using static XedDisasm;
    using static XedPatterns;

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        void EmitDisasmFields(WsContext context, ConstLookup<DisasmDetailDoc,Index<DisasmDetail>> src)
        {
            var docs = src.Keys;
            core.iter(docs, doc => EmitDisasmFields(context,doc, src[doc]), PllExec);
        }

        void EmitDisasmFields(WsContext context, DisasmDetailDoc doc, Index<DisasmDetail> details)
        {
            const string RenderPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.File;
            var buffer = text.buffer();

            for(var i=0u; i<file.LineCount; i++)
            {
                ref readonly var detail = ref doc[i].Detail;
                ref readonly var ops = ref detail.Ops;
                ref readonly var form = ref detail.InstForm;
                ref readonly var @class = ref detail.InstClass;
                ref readonly var block = ref doc[i].Block;
                ref readonly var lines = ref block.Lines;
                ref readonly var summary = ref block.Summary;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;

                var result = DisasmParse.parse(lines.XDis.Content, out XDis xdis);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }

                var state = RuleState.Empty;
                try
                {
                    var props = kvp(lines);

                    var f = fields(lines, props);
                    XedState.update(f, ref state);
                    var members = ByteBlock128.Empty;
                    var kinds = recover<FieldKind>(members.Bytes);
                    var count = f.Members().Members(kinds);

                    ref var field = ref f[K.INVALID];

                    var ocindex = XedState.ocindex(state);
                    buffer.AppendLine(RP.PageBreak240);
                    buffer.AppendLine(lines.Format());
                    buffer.AppendLine(RP.PageBreak80);
                    buffer.AppendLineFormat(RenderPattern, nameof(xdis.Asm), xdis.Asm);
                    buffer.AppendLineFormat(RenderPattern, nameof(xdis.Category), xdis.Category);
                    buffer.AppendLineFormat(RenderPattern, nameof(xdis.Extension), xdis.Extension);
                    buffer.AppendLineFormat(RenderPattern, nameof(xdis.Encoded), xdis.Encoded);

                    buffer.AppendLine(RP.PageBreak80);
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var kind = ref skip(kinds,k);
                        buffer.AppendLineFormat(RenderPattern, kind, f[kind].Format());
                    }

                    DisasmRender.RenderOps(ops,buffer);
                    buffer.AppendLine();
                }
                catch(Exception e)
                {
                    Write(e.ToString());
                    Write(e.Message,FlairKind.Error);
                    break;
                }
            }

            FileEmit(buffer.Emit(), file.LineCount, DisasmFieldsPath(context,file.Source), TextEncodingKind.Asci);
        }
    }
}