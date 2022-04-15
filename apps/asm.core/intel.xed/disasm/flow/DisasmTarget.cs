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

            readonly XedPaths XedPaths;

            FS.FilePath OutputPath;

            public DisasmTarget()
            {
                XedPaths = XedPaths.Service;
            }

            long Tokens;

            public DisasmToken Starting(in FileRef src)
            {
                DisasmToken token = (uint)inc(ref Tokens);
                Buffer = new(src);
                ProcessingFile(token);
                return token;
            }

            public void Finished(DisasmToken token)
            {
                Ran(Buffer.Flow, $"Processed {Buffer.Source}");
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

            void StateComputed(in RuleState state, Index<FieldKind> fields)
            {
                var dst = text.buffer();
                for(var i=0; i<fields.Count; i++)
                {
                    ref readonly var field = ref fields[i];
                    var cell = XedState.cell(state, field);
                    dst.AppendLineFormat("{0,-8} | {1,-22} | {2}", i, field, cell);
                }
                dst.AppendLine(RP.PageBreak80);
            }

            void StateComputed(uint seq)
            {
                Buffer.State(StateComputed);
            }

            void XDisComputed(uint seq)
            {
                ref readonly var value = ref Buffer.XDis;
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