//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [Free]
        public interface ITable : IEntity
        {

        }

        [Free]
        public interface ITable<T> : ITable, IEntity<T>
            where T : ITable<T>
        {
        }
    }
}