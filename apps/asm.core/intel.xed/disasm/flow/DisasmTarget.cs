//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        public class DisasmTarget : AppServiceClient<DisasmTarget>, IDisasmTarget
        {
            DisasmBuffer Buffer;

            readonly ConcurrentDictionary<uint,string> OutBlocks = new();

            int Counter;

            public DisasmTarget()
            {
                Counter = 0;
            }

            void Append(uint seq, string src)
            {
                OutBlocks.AddOrUpdate(seq, _ => src, (_,block) => block + src);
            }

            WsProjects Projects => Service(Wf.WsProjects);

            FS.FilePath OutputPath(in FileRef src)
                => Projects.XedDisasmDir(Context.Project) + FS.file(string.Format("{0}.targets", src.Path.FileName.WithoutExtension.Format()), FS.Txt);

            long Tokens;

            public DisasmToken Starting(in FileRef src)
            {
                DisasmToken token = (uint)inc(ref Tokens);
                Counter = 0;
                Buffer = new(src);
                ProcessingFile(token);
                return token;
            }

            public void Finished(DisasmToken token)
            {
                Ran(Buffer.Flow, $"Processed {Buffer.Source}");
                var keys = OutBlocks.Keys.Array().Sort();
                var dst = text.buffer();
                for(var i=0; i<keys.Length; i++)
                    dst.Append(OutBlocks[skip(keys,i)]);
                FileEmit(dst.Emit(), Counter, OutputPath(Buffer.Source));
            }

            public Task Computed(in DisasmFile src)
            {
                Buffer.File = src;
                return run(() => FileComputed());
            }

            public Task Computed(uint seq, in DetailBlock src)
            {
                Buffer.Block = src;
                return run(() => BlockComputed(seq));
            }

            public Task Computed(in DisasmSummaryDoc src)
            {
                Buffer.Summary = src;
                return run(() => SummaryComputed());
            }

            public Task Computed(uint seq, in RuleState src)
            {
                Buffer.State() = src;
                return run(() => StateComputed(seq));
            }

            public Task Computed(uint seq, in XDis src)
            {
                Buffer.XDis = src;
                return run(() => XDisComputed(seq));
            }

            public Task Computed(uint seq, in DisasmProps src)
            {
                Buffer.Props = src;
                return run(() => PropsComputed(seq));
            }

            public Task Computed(uint seq, in Fields src)
            {
                return run(() => FieldsComputed(seq));
            }

            public Task Computed(uint seq, in EncodingExtract src)
            {
                Buffer.Encoding = src;
                return run(() => EncodingComputed(seq));
            }

            public Task Computed(uint seq, ReadOnlySpan<FieldKind> src)
            {
                Buffer.Cache(src);
                return run(() => KindsComputed(seq));
            }

            void ProcessingFile(DisasmToken token)
            {
                Buffer.Flow = Running($"Processing {Buffer.Source}");
            }

            void FileComputed()
            {
                ref readonly var value = ref Buffer.File;
            }

            void SummaryComputed()
            {
                ref readonly var value = ref Buffer.Summary;
            }

            void BlockComputed(uint seq)
            {
                ref readonly var value = ref Buffer.Block;
            }

            void StateComputed(uint seq, in RuleState state, ReadOnlySpan<FieldKind> fields)
            {
                var dst = text.buffer();

                dst.AppendLine(RP.PageBreak80);

                for(var i=0; i<fields.Length; i++)
                {
                    var cell = XedState.cell(state, skip(fields,i));
                    dst.AppendLineFormat("{0,-24} | {1}", cell.Field, cell.Format());
                    inc(ref Counter);
                }
                dst.AppendLine(RP.PageBreak80);

                Append(seq, dst.Emit());
            }

            void StateComputed(uint seq)
            {
                Buffer.State(seq,StateComputed);
            }

            void XDisComputed(uint seq)
            {
                ref readonly var value = ref Buffer.XDis;
                var dst = text.buffer();
                dst.AppendLineFormat("{0,-24} | {1}", nameof(value.Asm), value.Asm);
                dst.AppendLineFormat("{0,-24} | {1}", nameof(value.Category), value.Category);
                dst.AppendLineFormat("{0,-24} | {1}", nameof(value.Extension), value.Extension);
                dst.AppendLineFormat("{0,-24} | {1}", nameof(value.IP), value.IP);
                dst.AppendLineFormat("{0,-24} | {1}", nameof(value.Encoded), value.Encoded);
                Append(seq, dst.Emit());
            }

            void FieldsComputed(uint seq)
            {

            }

            void PropsComputed(uint seq)
            {
                ref readonly var value = ref Buffer.Props;
            }

            void KindsComputed(uint seq)
            {

            }

            void EncodingComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.Encoding;
            }
        }
    }
}