//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISysVar : IHashed
    {
        VarName Name {get;}

        dynamic Value {get;}
    }

    [Free]
    public interface ISysVar<V> : ISysVar
        where V : IEquatable<V>, IComparable<V>, new()
    {
        new V Value {get;}

        dynamic ISysVar.Value
            => Value;

    }

    [Free]
    public interface ISysVar<N,V> : ISysVar<V>
        where N : unmanaged, INamed<N>
        where V : IEquatable<V>, IComparable<V>, new()
    {
        new N Name {get;}

        VarName ISysVar.Name
            => new VarName(Name.Format());
    }

    [Free]
    public interface ISysVar<S,N,V> : IEquatable<S>, IComparable<S>
        where N : unmanaged, INamed<N>
        where V : IEquatable<V>, IComparable<V>, new()
    {

    }
}