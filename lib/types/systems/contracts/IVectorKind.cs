//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVectorType : ISizedType
    {
        /// <summary>
        /// The vector numeric cell kind
        /// </summary>
        ScalarType CellType {get;}

        uint CellCount => 0;
    }

    /// <summary>
    /// Characterizes an F-bound polymorphic reification that identifies an intrinsic vector generic type definition
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    [Free]
    public interface IVectorType<F,W> : IVectorWidth<F>, IDataWidth
        where F : struct, IVectorType<F,W>
        where W : unmanaged, ITypeWidth
    {
        bool IEquatable<F>.Equals(F other)
            => true;

        DataWidth IDataWidth.DataWidth
            => Widths.data<W>();
    }

    [Free]
    public interface IVectorType<F,W,T> : IVectorType<F,W>, IVectorType
        where F : struct, IVectorType<F,W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        NumericKind CellKind
            =>NumericKinds.kind<T>();

        ScalarType IVectorType.CellType
            => default;
    }
}