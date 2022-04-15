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

            Task Computed(uint seq, in DetailBlock src);

            Task Computed(uint seq, in RuleState src);

            Task Computed(uint seq, in XDis src);

            Task Computed(uint seq, in Fields src);

            Task Computed(uint seq, ReadOnlySpan<FieldKind> src);

            Task Computed(uint seq, in EncodingExtract src);

            Task Computed(uint seq, in DisasmProps src);

            void Finished(DisasmToken token);
        }
    }
}