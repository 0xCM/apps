//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedOps;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static DisasmFieldBuffer fields()
            => DisasmFieldBuffer.allocate();

        public static ref DisasmFieldBuffer fields(in DetailBlock src, ref DisasmFieldBuffer dst)
        {
            dst.Clear();
            ref readonly var lines = ref src.SummaryLines;
            dst.Props = props(lines.Block);
            FieldParser.parse(dst.Props, dst.Fields, false);
            dst.Asm = asminfo(lines.Block);
            dst.Lines = lines.Block;
            dst.Detail = src.DetailRow;
            dst.Summary = lines.Row;
            dst.Selected = dst.Fields.MemberKinds();
            XedOps.update(dst.Fields, dst.Selected, ref dst.State);
            dst.Encoding = XedState.Code.encoding(dst.State, lines.Row.Encoded);
            return ref dst;
        }
    }
}