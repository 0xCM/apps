//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasm
    {
        public interface IDisasmTarget
        {
            DisasmToken Starting(in FileRef src);

            Task Computed(DisasmToken token, in DisasmFile src);

            Task Computed(DisasmToken token, in DetailBlock src);

            Task Computed(DisasmToken token, in DisasmSummaryDoc src);

            Task Computed(DisasmToken token, in RuleState src);

            Task Computed(DisasmToken token, in XDis src);

            Task Computed(DisasmToken token, in Fields src);

            Task Computed(DisasmToken token, ReadOnlySpan<FieldKind> src);

            Task Computed(DisasmToken token, in EncodingExtract src);

            Task Computed(DisasmToken token, in DisasmProps src);

            void Finished(DisasmToken token);
        }
    }
}