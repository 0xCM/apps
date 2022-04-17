//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public class DisasmFields : AppServiceClient<DisasmFields>
        {
            WsProjects Projects => Service(Wf.WsProjects);

            public void EmitFields()
            {
                var lookup = resequence(docs(Context,PllExec));
                iter(lookup.Keys, doc => EmitFields(Context,doc, TargetPath(Context,doc.File.Source)), PllExec);
            }

            public FS.FilePath TargetPath(WsContext context, in FileRef src)
                => Projects.XedDisasmDir(context.Project) + FS.file(string.Format("{0}.fields", src.Path.FileName.WithoutExtension), FS.Txt);

            void EmitFields(WsContext context, DisasmDetailDoc src, FS.FilePath dst)
            {
                var emitting = EmittingFile(dst);
                var emitter = new FieldEmitter(dst);
                var count = emitter.Emit(src);
                EmittedFile(emitting,count);
            }

            static ConstLookup<DisasmDetailDoc,Index<DetailBlockRow>> resequence(ConstLookup<FileRef,DisasmDetailDoc> src)
            {
                var buffer = cdict<DisasmDetailDoc,Index<DetailBlockRow>>();
                var kvp = core.map(src.Values, doc => (doc, details: doc.Blocks.ToArray().Select(x => x.DetailRow)));
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
                iter(files, file => dst.TryAdd(file, details(context,file)), pll);
                return dst;
            }
        }
    }
}