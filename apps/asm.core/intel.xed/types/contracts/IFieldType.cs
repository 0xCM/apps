//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [Free]
        public interface IFieldType : IDataType
        {
            FieldKind Field {get;}
        }

        [Free]
        public interface IFieldType<T> : IFieldType, IDataType<T>
            where T : unmanaged, IFieldType<T>
        {
        }
    }
}