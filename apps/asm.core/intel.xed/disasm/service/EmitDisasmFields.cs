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

                var state = RuleState.Empty;
                try
                {
                    var f = fields(file, i);
                    XedState.update(f, ref state);
                    ref var field = ref f[K.INVALID];

                    var ocindex = XedState.ocindex(state);
                    buffer.AppendLine(RP.PageBreak240);
                    buffer.AppendLine(lines.Format());
                    buffer.AppendLine(RP.PageBreak80);

                    {
                        field = ref f[K.ICLASS];
                        var value = XedState.iclass(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    //buffer.AppendLineFormat(RenderPattern, nameof(IClass), detail.InstClass);
                    buffer.AppendLineFormat(RenderPattern, "IFORM", detail.InstForm);
                    buffer.AppendLineFormat(RenderPattern, "OcMap", XedPatterns.ockind(ocindex));
                    //var encoding  = XedState.encoding(state, summary.Encoded);

                    buffer.AppendLineFormat(RenderPattern, nameof(summary.Encoded), summary.Encoded);
                    buffer.AppendLineFormat(RenderPattern, nameof(summary.IP), summary.IP);
                    buffer.AppendLineFormat(RenderPattern, nameof(summary.Asm), summary.Asm);
                    buffer.AppendLineFormat(RP.PageBreak80);

                    {
                        field = ref f[K.NOMINAL_OPCODE];
                        var value = XedState.ocbyte(state);
                        buffer.AppendLineFormat(RenderPattern, string.Format("{0}:{1}", field.Kind,"hex"), XedRender.format(value));
                        buffer.AppendLineFormat(RenderPattern, string.Format("{0}:{1}", field.Kind,"bits"), BitRender.format8x4(value));
                    }

                    {
                        field = ref f[K.EASZ];
                        var value = XedState.easz(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    {
                        field = ref f[K.EOSZ];
                        ref readonly var value = ref XedState.eosz(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    {
                        field = ref f[K.MODE];
                        ref readonly var value = ref XedState.mode(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.OSZ)
                    {
                        field = ref f[K.OSZ];
                        ref readonly var value = ref state.OSZ;
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.ASZ)
                    {
                        field = ref f[K.ASZ];
                        ref readonly var value = ref state.ASZ;
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.DF64)
                    {
                        field = ref f[K.DF64];
                        ref readonly var value = ref state.DF64;
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.DF32)
                    {
                        field = ref f[K.DF32];
                        ref readonly var value = ref state.DF32;
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.NSEG_PREFIXES != 0)
                    {
                        field = ref f[K.NSEG_PREFIXES];
                        ref readonly var value = ref state.NSEG_PREFIXES;
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.HINT != 0)
                    {
                        field = ref f[K.HINT];
                        ref readonly var value = ref XedState.hint(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    if(state.REP != 0)
                    {
                        field = ref f[K.REP];
                        ref readonly var value = ref XedState.rep(state);
                        buffer.AppendLineFormat(RenderPattern, field.Kind, value);
                    }

                    DisasmRender.RenderOps(ops,buffer);
                    buffer.AppendLine();
                }
                catch(Exception e)
                {
                    Write(e.Message,FlairKind.Error);
                    break;
                }
            }

            FileEmit(buffer.Emit(), file.LineCount, DisasmFieldsPath(context,file.Source), TextEncodingKind.Asci);
        }
    }
}