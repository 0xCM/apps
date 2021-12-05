//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public interface IFieldValue
    {
        FieldInfo Field {get;}

        object Value {get;}
    }

    public interface IFieldValue<S,T> : IFieldValue
    {
        new T Value {get;}

        object IFieldValue.Value
            => Value;
    }
}