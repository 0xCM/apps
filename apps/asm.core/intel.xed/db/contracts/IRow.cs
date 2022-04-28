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