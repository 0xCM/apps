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
        public interface IEntity<T> : IKeyed<T>
            where T : IEntity<T>
        {
            ref readonly Index<Relation> Relations {get;}
        }
    }
}