//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct DisasmOpDetail
        {
            public const string RenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            static string[] ColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

            public static string Header(int index)
                => string.Format(RenderPattern, ColPatterns.Select(x => string.Format(x, index)));

            public DisasmOpInfo OpInfo;

            public OpWidth OpWidth;

            public OpName OpName;

            public DisasmOp Def;

            public @string RuleDescription;

            public TextBlock DefDescription;

            public byte Index
            {
                [MethodImpl(Inline)]
                get => OpInfo.Index;
            }

            public OpAction Action
            {
                [MethodImpl(Inline)]
                get => OpInfo.Action;
            }

            public string Format()
                => DefDescription;

            public override string ToString()
                => Format();
        }
    }
}