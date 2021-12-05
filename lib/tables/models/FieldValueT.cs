//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Covers a field along with a value that was either extracted from a field instance or that may be pushed into a field instance
    /// </summary>
    /// <typeparam name="T">The field value type</param>
    public readonly struct FieldValue<T> : IFieldValue<T,object>
        where T : struct
    {
        public FieldInfo Field {get;}

        public object Value {get;}

        [MethodImpl(Inline)]
        public FieldValue(FieldInfo field, object value)
        {
            Field = field;
            Value = value;
        }
    }
}