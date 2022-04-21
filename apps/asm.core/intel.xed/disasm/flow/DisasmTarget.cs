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
        public class DisasmTarget : IDisasmTarget
        {
            DisasmBuffer Buffer;

            int Counter;

            HashSet<FieldKind> Exclusions;

            public DisasmTarget()
            {
                Counter = 0;
                Exclusions = core.hashset(K.TZCNT,K.LZCNT,K.MAX_BYTES);
                Running += Nothing;
                Ran += Nothing;
                BlockComputed += Nothing;
                RuleStateComputed += StateComputed;
                InfoComputed += Nothing;
                ExtractComputed += Nothing;
                PropsComputed += Nothing;
                FieldsComputed += Nothing;
            }

            protected event Receiver<FileRef> Running;

            protected event Action<DisasmToken> Ran;

            protected event DisasmReceiver<DetailBlock> BlockComputed;

            protected event StateReceiver RuleStateComputed;

            protected event DisasmReceiver<AsmInfo> InfoComputed;

            protected event DisasmReceiver<EncodingExtract> ExtractComputed;

            protected event DisasmReceiver<DisasmProps> PropsComputed;

            protected event FieldReceiver FieldsComputed;

            void IDisasmTarget.Computed(uint seq, in DetailBlock src)
            {
                BlockComputed(seq,src);
            }

            void IDisasmTarget.Computed(uint seq, in OperandState src)
            {
                Buffer.State(seq, src, RuleStateComputed);
            }

            void IDisasmTarget.Computed(uint seq, in AsmInfo src)
            {
                Buffer.AsmInfo() = src;
                InfoComputed(seq, src);
            }

            void IDisasmTarget.Computed(uint seq, in Fields src)
            {
                FieldsComputed(seq,src);
            }

            void IDisasmTarget.Computed(uint seq, ReadOnlySpan<FieldKind> src)
            {
                Buffer.Cache(src);
            }

            void IDisasmTarget.Computed(uint seq, in EncodingExtract src)
            {
                Buffer.Encoding() = src;
                ExtractComputed(seq,src);
            }

            void IDisasmTarget.Computed(uint seq, in DisasmProps src)
            {
                Buffer.Props() = src;
                PropsComputed(seq,src);
            }

            public DisasmToken Starting(in FileRef src)
            {
                DisasmToken t = token();
                Counter = 0;
                Buffer = new(src);
                Running(src);
                return t;
            }

            void IDisasmTarget.Finished(DisasmToken token)
            {
                Ran(token);
            }

            void StateComputed(uint seq, in OperandState state, ReadOnlySpan<FieldKind> fields)
            {
                for(var i=0; i<fields.Length; i++)
                {
                    ref readonly var kind = ref skip(fields,i);
                    if(Exclusions.Contains(kind))
                        continue;

                    var cell = XedState.cell(state, skip(fields,i));
                    inc(ref Counter);
                }
            }

            static void Nothing(in FileRef src) {}

            static void Nothing(DisasmToken src) {}

            static void Nothing<T>(uint seq, in T src) {}

            static void Nothing(uint seq, in Fields src) {}
       }
    }
}