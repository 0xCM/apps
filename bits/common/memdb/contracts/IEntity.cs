//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [Free]
        public interface IEntity : IElement
        {
            uint Key {get;}
        }

        [Free]
        public interface IEntity<T> : IEntity, IElement<T>
            where T : IEntity<T>
        {

        }
    }
}