//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [Free]
        public interface IType : IEntity
        {
            asci32 Name {get;}

            DataSize Size {get;}
        }

        [Free]
        public interface IType<T> : IType, IEntity<T>
            where T : IType<T>
        {

        }
    }
}