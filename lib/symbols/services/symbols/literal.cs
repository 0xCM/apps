//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        /// <summary>
        /// Populates a <see cref='SymLiteralRow<E>'/> from a specified source <see cref='Sym<E>'/>
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <typeparam name="E">The defining type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref SymLiteral<E> literal<E>(in Sym<E> src, out SymLiteral<E> dst)
            where E : unmanaged
        {
            var type = typeof(E);
            dst.Component = typeof(E).Assembly;
            dst.DataType = PrimalBits.kind(type);
            dst.Class = src.Class;
            dst.Size = src.Size;
            dst.Description = src.Description;
            dst.Value = src.Value;
            dst.Identity = src.Identity;
            dst.Name = src.Name;
            dst.Position = (ushort)src.Key.Value;
            dst.Symbol = (src.Kind, src.Expr.Format());
            dst.Type = src.Type;
            dst.Hidden = src.Hidden;
            return ref dst;
        }
    }
}