//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IString : INullity, IHashed, ICellular
    {

    }

    [Free]
    public interface IString<T> : IString, ICellular<T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {

    }

    [Free]
    public interface IString<F,T> : IString<T>, IEquatable<F>, IComparable<F>
        where F : IString<F,T>, new()
        where T : unmanaged, IEquatable<T>, IComparable<T>
    {

    }

}