//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDataType : ITextual
    {
        Type ContentType {get;}

        /// <summary>
        /// Specifies the reifying type
        /// </summary>
        Type CoverType
            => GetType();
    }

    [Free]
    public interface IDataType<T> : IDataType
    {
        Type IDataType.ContentType
            => typeof(T);
    }

    [Free]
    public interface IDataTypeEquatable<T> : IDataType<T>, IEquatable<T>
    {

    }

    [Free]
    public interface IDataTypeComparable<T> : IDataTypeEquatable<T>, IComparable<T>
    {
        bool IEquatable<T>.Equals(T src)
            => CompareTo(src) == 0;
    }

    [Free]
    public interface IDataType<C,T> : IDataType<T>
        where C : IDataType<C,T>
    {
        Type IDataType.CoverType
            => typeof(C);

        C Container
            => (C)this;
    }
}