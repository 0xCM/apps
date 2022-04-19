//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Symbols
    {
        [Op, Closures(Closure)]
        internal static Sym untyped<T>(Sym<T> src)
            where T : unmanaged
                => new Sym(src.Identity, src.Class, src.Key, src.Type, bw64(src.Kind), src.Name, src.Expr.Text, src.Description, src.Hidden, src.Kind);

        public static SymIndex untyped(Type src)
        {
            var factory = typeof(Symbols).Method("index").MakeGenericMethod(src);
            var index = (ISymIndex)factory.Invoke(null, core.array<object>());
            return index.Untyped();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static SymLiteralRow untype<E>(in SymLiteral<E> src)
            where E : unmanaged
        {
            var dst = new SymLiteralRow();
            dst.Component = src.Component.SimpleName;
            dst.Type = src.Type;
            dst.Class = src.Class;
            dst.Position = src.Position;
            dst.Name = src.Name;
            dst.Symbol = src.Symbol;
            dst.DataType = src.DataType;
            dst.Value = src.Value;
            dst.NumericBase = NumericBaseKind.Base10;
            dst.Description = src.Description;
            dst.Hidden = src.Hidden;
            dst.Identity = src.Identity;
            return dst;
        }
   }
}