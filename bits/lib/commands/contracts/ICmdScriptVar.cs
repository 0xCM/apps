//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdScriptVar : IVarValue
    {

    }

    [Free]
    public interface ICmdScriptVar<T> : ICmdScriptVar, IVarValue<T>
    {

    }
}