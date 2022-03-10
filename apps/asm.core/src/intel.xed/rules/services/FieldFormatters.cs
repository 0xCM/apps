//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedFormatters;

    partial class XedRules
    {
        public delegate string FieldFormatter(FieldValue src);

        public delegate string FieldFormatter<T>(FieldValue<T> src)
            where T : unmanaged;

        public sealed class FieldFormatters : Dictionary<FieldKind,FieldFormatter>
        {
            [MethodImpl(Inline), Op]
            public static string easz(FieldValue src)
            {
                var data = (EASZ)src.Data;
                var dst = width(data).ToString();
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static string eosz(FieldValue src)
            {
                var data = (EOSZ)src.Data;
                var dst = width(data).ToString();
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static string mode(FieldValue src)
            {
                var data = (ModeKind)src.Data;
                var dst = width(data).ToString();
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static string bcast(FieldValue src)
                => format((BCastKind)src.Data);

            public FieldFormatters()
            {
                [MethodImpl(Inline)]
                static string format(FieldValue src)
                    => RuleTables.format(src);

                iter(new ReflectedFields().LeftValues, k => this[k] = format);
            }
        }
    }
}