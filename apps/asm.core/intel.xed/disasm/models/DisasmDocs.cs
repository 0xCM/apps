//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        public class DisasmDocs : IPaired<DisasmSummaryDoc,DisasmDetailDoc>
        {
            public readonly DisasmSummaryDoc Summary;

            public readonly DisasmDetailDoc Detail;

            [MethodImpl(Inline)]
            public DisasmDocs(DisasmSummaryDoc summary, DisasmDetailDoc detail)
            {
                Summary = summary;
                Detail = detail;
            }

            DisasmSummaryDoc IPaired<DisasmSummaryDoc, DisasmDetailDoc>.Left
                => Summary;

            DisasmDetailDoc IPaired<DisasmSummaryDoc, DisasmDetailDoc>.Right
                => Detail;

            [MethodImpl(Inline)]
            public void Deconstruct(out DisasmSummaryDoc s, out DisasmDetailDoc d)
            {
                s = Summary;
                d = Detail;
            }

            [MethodImpl(Inline)]
            public static implicit operator DisasmDocs((DisasmSummaryDoc s, DisasmDetailDoc d) src)
                => new DisasmDocs(src.s,src.d);
        }
    }
}