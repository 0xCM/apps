//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct DisasmOpDetails : IIndex<DisasmOpDetail>
        {
            public const string RenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            static string[] ColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Prop2"};

            public static string Header(int index)
                => string.Format(RenderPattern, ColPatterns.Select(x => string.Format(x, index)));

            public Index<DisasmOpDetail> Details;

            [MethodImpl(Inline)]
            public DisasmOpDetails(DisasmOpDetail[] src)
            {
                Details = src;
            }

            public DisasmOpDetail[] Storage
            {
                [MethodImpl(Inline)]
                get => Details.Storage;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Details.Count;
            }

            public int Length
            {
                [MethodImpl(Inline)]
                get => Details.Length;
            }

            public ref DisasmOpDetail this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Details[i];
            }

            public ref DisasmOpDetail this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Details[i];
            }

            public string Format()
                => XedFormatters.format(this);


            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator DisasmOpDetails(DisasmOpDetail[] src)
                => new DisasmOpDetails(src);

            [MethodImpl(Inline)]
            public static implicit operator DisasmOpDetail[](DisasmOpDetails src)
                => src.Storage;
        }
    }
}