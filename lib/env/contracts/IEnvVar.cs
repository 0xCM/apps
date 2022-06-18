//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEnvVar : IVarValue, ISetting<VarSymbol,string>
    {
         VarSymbol ISetting<VarSymbol,string>.Name
            => VarName;

        string ISetting<string>.Value
            => VarValue;
    }

    [Free]
    public interface IEnvVar<T> : IEnvVar, IVarValue<T>
    {

    }

    [Free]
    public interface IEnvVar<V,T> : IEnvVar<T>, IEquatable<V>, IComparable<V>
        where V : IEnvVar<V,T>
    {

    }
}