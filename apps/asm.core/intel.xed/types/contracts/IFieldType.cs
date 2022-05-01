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
        public interface IFieldType : IRuleType
        {
            FieldKind Field {get;}
        }

        [Free]
        public interface IFieldType<T> : IFieldType, IRuleType<T>
            where T : unmanaged, IFieldType<T>
        {
        }

    }
}