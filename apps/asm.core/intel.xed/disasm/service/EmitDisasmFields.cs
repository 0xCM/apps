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

    partial class XedDisasmSvc
    {
        void EmitDisasmFields(WsContext context, ConstLookup<DisasmDetailDoc,Index<DisasmDetail>> src)
        {
            var docs = src.Keys;
            core.iter(docs, doc => EmitDisasmFields(context,doc), PllExec);
        }

        public static Span<FieldKind> members(in Fields fields, out Span<FieldKind> dst)
        {
            var storage = ByteBlock128.Empty;
            var kinds = recover<FieldKind>(storage.Bytes);
            var members = fields.Members();
            var count = members.Members(kinds);
            dst = slice(kinds,0,count);
            return dst;
        }

        void EmitDisasmFields(WsContext context, DisasmDetailDoc doc)
        {
            using var emitter = new FieldEmitter(file => DisasmFieldsPath(context,file), (data,count,path) => FileEmit(data,count,path, TextEncodingKind.Asci));
            emitter.Emit(doc);
        }
    }
}