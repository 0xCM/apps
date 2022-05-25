//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class SymHeaps
    {
        /// <summary>
        /// Discovers symbolic literals defined in a specified component collection
        /// </summary>
        public static Index<SymLiteralRow> symlits(Assembly[] src)
            => Symbols.literals(src);

        /// <summary>
        /// Discovers the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public static Index<SymLiteralRow> symlits<E>()
            where E : unmanaged, Enum
                => Symbols.literals<E>();
    }
}
