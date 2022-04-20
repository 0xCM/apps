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
        public delegate void DisasmReceiver<T>(uint seq, in T src);

        public delegate void StateReceiver(uint seq, in RuleState state, ReadOnlySpan<FieldKind> fields);

        public delegate void FieldReceiver(uint seq, in Fields src);

        public class DisasmBuffer
        {
            public readonly FileRef Source;

            readonly Index<FieldKind> _FieldKinds;

            DataFile _DataFile;

            DetailBlock _Block;

            Summary _Summary;

            AsmInfo _AsmInfo;

            DisasmProps _Props;

            [MethodImpl(Inline)]
            public ref DataFile DataFile()
                => ref _DataFile;

            [MethodImpl(Inline)]
            public ref DetailBlock Block()
                => ref _Block;

            [MethodImpl(Inline)]
            public ref Summary Summary()
                => ref _Summary;

            [MethodImpl(Inline)]
            public ref AsmInfo AsmInfo()
                => ref _AsmInfo;

            [MethodImpl(Inline)]
            public ref DisasmProps Props()
                => ref _Props;

            public uint FieldCount;

            EncodingExtract _Encoding;

            [MethodImpl(Inline)]
            public ref EncodingExtract Encoding()
                => ref _Encoding;

            object StateLock = new();

            public void State(uint seq, in RuleState state, StateReceiver receiver)
            {
                lock(StateLock)
                    receiver(seq, state, slice(_FieldKinds.View, 0, FieldCount));
            }

            public void Cache(ReadOnlySpan<FieldKind> src)
            {
                lock(StateLock)
                {
                    FieldCount = (uint)src.Length;
                    for(var i=0; i<src.Length; i++)
                        _FieldKinds[i] = skip(src,i);
                }
            }

            public DisasmBuffer(in FileRef src)
            {
                Source = src;
                _FieldKinds = alloc<FieldKind>(Fields.MaxCount);
                _DataFile = XedDisasm.DataFile.Empty;
                _Block = DetailBlock.Empty;
                _Summary = XedDisasm.Summary.Empty;
                _AsmInfo = XedRules.AsmInfo.Empty;
                _Props = DisasmProps.Empty;
                _Encoding = EncodingExtract.Empty;
            }
        }
    }
}