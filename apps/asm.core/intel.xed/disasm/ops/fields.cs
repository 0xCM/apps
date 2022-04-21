//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedFields;

    partial class XedDisasm
    {
        public static FieldBuffer fields()
            => FieldBuffer.init();

        public static ref FieldBuffer fields(in DetailBlock src, ref FieldBuffer dst)
        {
            dst.Clear();
            dst.Detail = src.DetailRow;
            dst.Lines = src.SummaryLines.Block;
            dst.Summary = src.SummaryLines.Row;
            parse(dst.Lines, out dst.AsmInfo).Require();
            parse(dst.Lines, out dst.Props);
            fields(dst.Props, dst.Fields, false);
            dst.FieldSelection = dst.Fields.MemberKinds();
            XedState.Edit.fields(dst.Fields, dst.FieldSelection, ref dst.State);
            dst.Encoding = XedState.Code.encoding(dst.State, src.SummaryLines.Row.Encoded);
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
                result = TableCalcs.parse(value, kind, out var pack);
                result.Require();
                dst.Update(pack);
                counter++;
            }
            return counter;
        }
    }
}