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
        public delegate void StateReceiver(uint seq, in RuleState state, ReadOnlySpan<FieldKind> fields);

        public class DisasmBuffer
        {
            public readonly FileRef Source;

            public WfExecFlow<string> Flow;

            public DisasmFile File;

            public DetailBlock Block;

            public DisasmSummaryDoc Summary;

            object StateLock = new();

            RuleState _State;

            [MethodImpl(Inline)]
            public ref RuleState State()
                => ref _State;

            public void State(uint seq, StateReceiver receiver)
            {
                lock(StateLock)
                    receiver(seq,_State, slice(_FieldKinds.View, 0, FieldCount));
            }

            public AsmInfo XDis;

            readonly Index<Field> _StateFields;

            readonly Index<FieldKind> _FieldKinds;

            public void Cache(ReadOnlySpan<FieldKind> src)
            {
                lock(StateLock)
                {
                    FieldCount = (uint)src.Length;
                    for(var i=0; i<src.Length; i++)
                        _FieldKinds[i] = skip(src,i);

                }
            }

            public uint FieldCount;

            public DisasmProps Props;

            public EncodingExtract Encoding;

            public DisasmBuffer(in FileRef src)
            {
                Source = src;
                _StateFields = alloc<Field>(Fields.MaxCount);
                _FieldKinds = alloc<FieldKind>(Fields.MaxCount);
                File = DisasmFile.Empty;
                Block = DetailBlock.Empty;
                Summary = DisasmSummaryDoc.Empty;
                _State = RuleState.Empty;
                XDis = AsmInfo.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
            }
        }
    }
}