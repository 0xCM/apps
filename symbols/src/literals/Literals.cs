//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class Literals
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static RuntimeLiteralValue<string> value(in RuntimeLiteral src)
        {
            var value = EmptyString;
            if(src.Kind == ClrLiteralKind.String)
                value = ((StringAddress)src.Data).Format();
            else
                value = src.Data.ToString();
            return new RuntimeLiteralValue<string>(value);
        }

        public static ItemList<Constant<T>> items<T>(string name, T[] src)
            => new (name, src.Mapi((i,x) => new ListItem<Constant<T>>((uint)i,x)));

        static string name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name,
                _ => sym.Name
            };
    }
}