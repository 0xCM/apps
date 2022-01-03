//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableFieldDef
    {
        public ushort FieldIndex {get;}

        public string FieldName {get;}

        public TypeSpec DataType {get;}

        [MethodImpl(Inline)]
        public TableFieldDef(ushort index, string name, TypeSpec type)
        {
            FieldIndex = index;
            FieldName = name;
            DataType = type;
        }

        public string Format()
            => string.Format("[{0:D2} {1}:{2}]", FieldIndex, FieldName, DataType);

        public override string ToString()
            => Format();
    }
}