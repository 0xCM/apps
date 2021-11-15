//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct RecordFieldSpec
    {
        public ushort FieldIndex {get;}

        public string FieldName {get;}

        public string DataType {get;}

        [MethodImpl(Inline)]
        public RecordFieldSpec(ushort index, string name, string type)
        {
            FieldIndex = index;
            FieldName = name;
            DataType = type;
        }

        public string Format()
            => string.Format("[{0} {1}:{2}]", FieldIndex, FieldName, DataType);

        public override string ToString()
            => Format();
    }
}