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
        public class DisasmBuffer
        {
            public readonly DisasmToken Token;

            public readonly FileRef Source;

            public WfExecFlow<string> Flow;

            public DisasmFile File;

            public DetailBlock Block;

            public DisasmSummaryDoc Summary;

            public RuleState State;

            public XDis XDis;

            public readonly Index<Field> StateFields;

            public readonly Index<FieldKind> FieldKinds;

            public uint FieldCount;

            public DisasmProps Props;

            public EncodingExtract Encoding;

            public DisasmBuffer(DisasmToken token, in FileRef src)
            {
                Token = token;
                Source = src;
                StateFields = alloc<Field>(Fields.MaxCount);
                FieldKinds = alloc<FieldKind>(Fields.MaxCount);
                File = DisasmFile.Empty;
                Block = DetailBlock.Empty;
                Summary = DisasmSummaryDoc.Empty;
                State = RuleState.Empty;
                XDis = XDis.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
            }
        }
    }
}