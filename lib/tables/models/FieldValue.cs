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

    public readonly struct FieldValue : IFieldValue<object,object>
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