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

            void Finished(DisasmToken token);

            void Computed(uint seq, in DetailBlock src);

            void Computed(uint seq, in OperandState src);

            void Computed(uint seq, in AsmInfo src);

            void Computed(uint seq, in Fields src);

            void Computed(uint seq, ReadOnlySpan<FieldKind> src);

            void Computed(uint seq, in EncodingExtract src);

            void Computed(uint seq, in DisasmProps src);
        }
    }
}