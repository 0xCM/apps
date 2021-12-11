//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdArg
    {
        uint Index {get;}

        string Name {get;}

        string Value {get;}
    }

    public interface ICmdArg<T> : ICmdArg
    {
        new T Value {get;}

        string ICmdArg.Value
            => Value.ToString();
    }
}