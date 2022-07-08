//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISysVar : IHashed
    {
        Name Name {get;}
    }

    [Free]
    public interface ISysVar<V> : ISysVar
        where V : IEquatable<V>, IComparable<V>, new()
    {
        V Value {get;}
    }

    [Free]
    public interface ISysVar<N,V> : ISysVar<V>
        where N : unmanaged, IDataType<N>, IExpr
        where V : IEquatable<V>, IComparable<V>, new()
    {
        new N Name {get;}

        Name ISysVar.Name
            => new Name(Name.Format());
    }

    [Free]
    public interface ISysVar<S,N,V> : IEquatable<S>, IComparable<S>
        where N : unmanaged, IDataType<N>, IExpr
        where V : IEquatable<V>, IComparable<V>, new()
    {

    }
}