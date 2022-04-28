//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [Free]
        public interface IRow : IEntity
        {

        }

        [Free]
        public interface IRow<T> : IRow, IEntity<T>
            where T : IRow<T>
        {

        }
    }
}