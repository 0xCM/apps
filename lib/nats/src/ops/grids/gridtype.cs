//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Grids
    {
        /// <summary>
        /// Defines a parametrically-specified grid type expression
        /// </summary>
        /// <typeparam name="W">The block width type</typeparam>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static GridType<W,M,N,T> gridtype<W,M,N,T>(W w = default, M m = default, N n = default, T t = default)
            where W : unmanaged, IDataWidth
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => default;
    }
}