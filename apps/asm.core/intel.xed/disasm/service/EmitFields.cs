//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void EmitFields(WsContext context)
        {
            var lookup = resequence(docs(context,PllExec));
            iter(lookup.Keys, doc => EmitFields(context,doc), PllExec);
        }

        static ConstLookup<DisasmDetailDoc,Index<DetailBlockRow>> resequence(ConstLookup<FileRef,DisasmDetailDoc> src)
        {
            var buffer = cdict<DisasmDetailDoc,Index<DetailBlockRow>>();
            var kvp = core.map(src.Values, doc => (doc, details: doc.View.ToArray().Select(x => x.Detail)));
            for(var j=0; j<kvp.Length; j++)
            {
                ref var details = ref seek(kvp,j).details;
                details.Sort();
                for(var i=0u; i<details.Length; i++)
                    seek(details,i).Seq = i;
                buffer[seek(kvp,j).doc] = details;
            }

            return buffer;
        }

        static ConstLookup<FileRef,DisasmDetailDoc> docs(WsContext context, bool pll)
        {
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, file => dst.TryAdd(file, doc(context,file)), pll);
            return dst;
        }

        void EmitFields(WsContext context, DisasmDetailDoc src)
        {
            using var emitter = new FieldEmitter(file => DocFieldsPath(context,file), (data,count,path) => FileEmit(data,count,path, TextEncodingKind.Asci));
            emitter.Emit(src);
        }
    }
}