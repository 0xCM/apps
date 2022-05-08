//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [Free]
        public interface IRow : IEntity, ISequential
        {
            uint IEntity.Key
                => Seq;
        }

        [Free]
        public interface IRow<T> : IRow, IEntity<T>, ISequential<T>
            where T : IRow<T>
        {

        }
    }
}