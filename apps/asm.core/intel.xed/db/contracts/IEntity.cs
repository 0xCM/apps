//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
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