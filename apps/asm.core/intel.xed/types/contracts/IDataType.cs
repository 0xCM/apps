//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [Free]
        public interface IDataType
        {
            asci32 Name {get;}

            TypeKind Kind {get;}

            DataSize Size => default;
        }

        [Free]
        public interface IDataType<T> : IDataType
            where T : unmanaged, IDataType<T>
        {
        }
    }
}