//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasm;

    public interface IXedDisasmTarget
    {
        Task Running(in FileRef src);

        Task Computed(in DisasmFile src);

        Task Computed(in DetailBlock src);

        Task Computed(in DisasmSummaryDoc src);

        Task Computed(in RuleState src);

        Task Computed(in XDis src);

        Task Computed(in Fields src);

        Task Computed(ReadOnlySpan<FieldKind> src);

        Task Computed(in EncodingExtract src);

        Task Computed(in DisasmProps src);

        Task Completed();
    }
}