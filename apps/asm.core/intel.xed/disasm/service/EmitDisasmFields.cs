//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        void EmitDisasmFields(WsContext context, ConstLookup<DisasmDetailDoc,Index<DetailBlockRow>> src)
        {
            var docs = src.Keys;
            core.iter(docs, doc => EmitDisasmFields(context,doc), PllExec);
        }

        void EmitDisasmFields(WsContext context, DisasmDetailDoc doc)
        {
            using var emitter = new FieldEmitter(file => DisasmFieldsPath(context,file), (data,count,path) => FileEmit(data,count,path, TextEncodingKind.Asci));
            emitter.Emit(doc);
        }
    }
}