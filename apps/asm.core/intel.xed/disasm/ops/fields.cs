//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedOperands;

    partial class XedDisasm
    {
        public static FieldBuffer fields()
            => FieldBuffer.allocate();

        public static ref FieldBuffer fields(in DetailBlock src, ref FieldBuffer dst)
        {
            dst.Clear();
            ref readonly var lines = ref src.SummaryLines;
            dst.Props = props(lines.Block);
            fields(dst.Props, dst.Fields, false);
            dst.AsmInfo = asminfo(lines.Block);
            dst.Lines = lines.Block;
            dst.Detail = src.DetailRow;
            dst.Summary = lines.Row;
            dst.FieldSelection = dst.Fields.MemberKinds();
            XedOperands.update(dst.Fields, dst.FieldSelection, ref dst.State);
            dst.Encoding = XedState.Code.encoding(dst.State, lines.Row.Encoded);
            return ref dst;
        }

        public static uint fields(DisasmProps props, Fields dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var result = Outcome.Success;
            var counter = 0u;
            var count = props.Count;
            var keys = props.Keys.Array();
            for(var i=0; i<count; i++)
            {
                var name = skip(keys,i);
                var value = props[name];
                if(name == nameof(InstForm))
                    continue;

                result = XedParsers.parse(name, out FieldKind kind);
                result.Require();
                dst.Update(FieldParser.pack(value, kind));
                counter++;
            }
            return counter;
        }
    }
}