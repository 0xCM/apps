//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdRender
    {
        public static string format<T>(ICmd<T> src)
            where T : struct, ICmd<T>
        {
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);

            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(__makeref(src), fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        static void render(TypedReference src, ReadOnlySpan<ClrFieldAdapter> fields, ITextBuffer dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RP.Assign, field.Name, field.GetValueDirect(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }

    }
}