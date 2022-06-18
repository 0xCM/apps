//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvSet
    {
        string Name {get;}

        T Value<T>(VarSymbol name)
            where T : IEquatable<T>;

        bool Value<T>(VarSymbol name, out T dst)
            where T : IEquatable<T>;

        ReadOnlySpan<VarSymbol> VarNames {get;}

        ReadOnlySpan<object> VarValues {get;}

        string ToString();
    }

    public interface IEnvSet<S> : IEnvSet
        where S : struct
    {

    }
}