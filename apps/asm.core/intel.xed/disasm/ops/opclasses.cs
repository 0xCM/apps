//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public static InstOpClass opclass(MachineMode mode, in OpInfo src)
        {
            var info = XedOperands.describe(src.WidthCode);
            var bitwidth = XedOperands.width(mode, src.WidthCode).Bits;
            var dst =  new InstOpClass {
                        Kind = src.Kind,
                        BitWidth = bitwidth,
                        ElementType = info.ElementType,
                        IsRegLit = XedOperands.IsRegLit(src.OpType),
                        IsRule = XedOperands.IsRule(src.OpType),
                        ElementCount = info.CellCount,
                        OpWidth = new OpWidth(src.WidthCode, bitwidth)
                    };

            return dst;
        }

        public static Index<InstOpClass> opclasses(Index<Document> src)
        {
            var buffer = hashset<InstOpClass>();
            foreach(var (summary,detail) in src)
                buffer.AddRange(detail.Blocks.Select(x => x.DetailRow).SelectMany(x => x.Ops).Select(x => opclass(ModeClass.Mode64, x.OpInfo)).Distinct());
            var dst = buffer.Array();
            return resequence(dst);
        }

        public static Index<InstOpClass> opclasses(Document src)
            => resequence(
                src.Detail.Blocks.Select(x => x.DetailRow)
                   .SelectMany(x => x.Ops)
                   .Select(x => opclass(ModeClass.Mode64, x.OpInfo))
                   .Distinct());
    }
}