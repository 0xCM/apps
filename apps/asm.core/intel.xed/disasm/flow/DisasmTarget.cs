//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        public class DisasmTarget : AppServiceClient<DisasmTarget>, IDisasmTarget
        {
            DisasmBuffer Buffer;

            readonly ConcurrentDictionary<uint,string> OutBlocks = new();

            int Counter;

            HashSet<FieldKind> Exclusions;

            public DisasmTarget()
            {
                Counter = 0;
                Exclusions = core.hashset(K.TZCNT,K.LZCNT,K.MAX_BYTES);
            }

            public DisasmToken Starting(in FileRef src)
            {
                OutBlocks.Clear();
                DisasmToken t = token();
                Counter = 0;
                Buffer = new(src);
                return t;
            }

            public void Finished(DisasmToken token)
            {

            }

            public void Computed(uint seq, in DetailBlock src)
            {
                Buffer.Block() = src;

            }

            public void Computed(uint seq, in RuleState src)
            {
                Buffer.State(seq, src, StateComputed);
            }

            public void Computed(uint seq, in AsmInfo src)
            {
                Buffer.AsmInfo() = src;
            }

            public void Computed(uint seq, in DisasmProps src)
            {
                Buffer.Props() = src;
            }

            public void Computed(uint seq, in Fields src)
            {

            }

            public void Computed(uint seq, in EncodingExtract src)
            {
                Buffer.Encoding() = src;
            }

            public void Computed(uint seq, ReadOnlySpan<FieldKind> src)
            {
                Buffer.Cache(src);
            }

            void StateComputed(uint seq, in RuleState state, ReadOnlySpan<FieldKind> fields)
            {
                var dst = text.buffer();

                for(var i=0; i<fields.Length; i++)
                {
                    ref readonly var kind = ref skip(fields,i);
                    if(Exclusions.Contains(kind))
                        continue;

                    var cell = XedState.cell(state, skip(fields,i));
                    inc(ref Counter);
                }
            }
        }
    }
}