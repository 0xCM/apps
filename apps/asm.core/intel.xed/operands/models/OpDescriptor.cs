//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct OpDescriptor
        {
            public static OpDescriptor calc(MachineMode mode, in PatternOp src)
            {
                var dst = Empty;
                dst.GprWidth = GprWidth.Empty;
                dst.Index = src.Index;
                dst.Name = src.Name;
                src.ElementType(out dst.ElementType);
                src.WidthCode(out dst.Code);
                var w = XedOperands.width(mode, dst.Code);
                if(w.IsNonEmpty)
                    dst.BitWidth = w.Bits;
                if(src.IsReg && src.RegLiteral(out dst.RegLit))
                    dst.BitWidth = XedOperands.width(dst.RegLit);
                if(src.Nonterminal(out dst.Rule))
                    GprWidth.widths(dst.Rule, out dst.GprWidth);
                var wi = XedOperands.describe(dst.Code);
                if(wi.SegType.CellCount > 1)
                    dst.Seg = new Segmentation(wi.SegType.DataWidth, wi.SegType.CellWidth, dst.ElementType.Indicator, wi.SegType.CellCount);
                return dst;
            }

            public byte Index;

            public OpName Name;

            public ElementType ElementType;

            public OpWidthCode Code;

            public ushort BitWidth;

            public Register RegLit;

            public Nonterminal Rule;

            public GprWidth GprWidth;

            public Segmentation Seg;

            public bool IsReg
            {
                [MethodImpl(Inline)]
                get => RegLit.IsNonEmpty;
            }

            public bool IsRule
            {
                [MethodImpl(Inline)]
                get => Rule.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Code == 0;
            }

            public string Format()
            {
                var uri = FS.FileUri.Empty;
                var sig = RuleSig.Empty;
                var detail = EmptyString;
                var bw = BitWidth.ToString();
                if(IsRule)
                {
                    uri = XedPaths.Service.CheckedTableDef(Rule, true, out sig);
                    detail = string.Format("{0}::{1}", Rule, uri);
                }
                else if(IsReg)
                    detail = RegLit.Format();

                if(GprWidth.IsNonEmpty)
                    bw = GprWidth.Format();

                return string.Format(RenderPattern, Index, Name, bw, Seg, ElementType, XedRender.format(Code), detail);
            }

            public override string ToString()
                => Format();

            const string RenderPattern = "{0,-2} {1,-14} {2,-6} {3,-12} {4,-6} {5,-3} {6}";

            public static OpDescriptor Empty => default;

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public readonly record struct Segmentation
            {
                const string RenderPattern = "{0}x{1}{2}x{3}n";

                public readonly ushort DataWidth;

                public readonly ushort ElementWidth;

                public readonly NumericIndicator Indicator;

                public readonly byte ElementCount;

                [MethodImpl(Inline)]
                public Segmentation(ushort dw, ushort ew, NumericIndicator i, byte n)
                {
                    DataWidth = dw;
                    ElementWidth = ew;
                    Indicator = i;
                    ElementCount = n;
                }

                public bool IsEmpty
                {
                    [MethodImpl(Inline)]
                    get => DataWidth == 0;
                }

                public string Format()
                    => IsEmpty ? EmptyString : string.Format(RenderPattern, DataWidth, ElementWidth, Indicator != 0 ? (char)Indicator : EmptyString, ElementCount);

                public override string ToString()
                    => Format();

                public static Segmentation Empty => default;
            }
        }
    }
}