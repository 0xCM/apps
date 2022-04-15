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

            public DisasmTarget()
            {

            }

            long Tokens;

            public DisasmToken Starting(in FileRef src)
            {
                DisasmToken token = (uint)inc(ref Tokens);
                Buffer = new(token,src);
                ProcessingFile(token);
                return token;
            }

            public void Finished(DisasmToken token)
            {
                Ran(Buffer.Flow, $"Processed {Buffer.Source}");
            }

            public Task Computed(DisasmToken token, in DisasmFile src)
            {
                Buffer.File = src;
                return run(() => FileComputed(token));
            }

            public Task Computed(DisasmToken token, in DetailBlock src)
            {
                Buffer.Block = src;
                return run(() => BlockComputed(token));
            }

            public Task Computed(DisasmToken token, in DisasmSummaryDoc src)
            {
                Buffer.Summary = src;
                return run(() => SummaryComputed(token));
            }

            public Task Computed(DisasmToken token, in RuleState src)
            {
                Buffer.State = src;
                return run(() => StateComputed(token));
            }

            public Task Computed(DisasmToken token, in XDis src)
            {
                Buffer.XDis = src;
                return run(() => XDisComputed(token));
            }

            public Task Computed(DisasmToken token, in DisasmProps src)
            {
                Buffer.Props = src;
                return run(() => PropsComputed(token));
            }

            public Task Computed(DisasmToken token, in Fields src)
            {
                return run(() => FieldsComputed(token));
            }

            public Task Computed(DisasmToken token, in EncodingExtract src)
            {
                Buffer.Encoding = src;
                return run(() => EncodingComputed(token));
            }

            public Task Computed(DisasmToken token, ReadOnlySpan<FieldKind> src)
            {
                var buffer = Buffer;
                buffer.FieldCount = (uint)src.Length;
                for(var i=0; i<src.Length; i++)
                    buffer.FieldKinds[i] = skip(src,i);

                return run(() => KindsComputed(token));
            }

            void ProcessingFile(DisasmToken token)
            {
                Buffer.Flow = Running($"Processing {Buffer.Source}");
            }

            void FieldsComputed(DisasmToken token)
            {

            }

            void FileComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.File;
            }

            void BlockComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.Block;
            }

            void SummaryComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.Summary;
            }

            void StateComputed(DisasmToken token)
            {
                ref readonly var state = ref Buffer.State;
                ref readonly var fields = ref Buffer.FieldKinds;
                for(var i=0; i<fields.Count; i++)
                {
                    var cell = XedState.cell(state,fields[i]);
                }
            }

            void XDisComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.XDis;
            }

            void PropsComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.Props;
            }

            void KindsComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.FieldKinds;

            }

            void EncodingComputed(DisasmToken token)
            {
                ref readonly var value = ref Buffer.Encoding;
            }
        }
    }
}