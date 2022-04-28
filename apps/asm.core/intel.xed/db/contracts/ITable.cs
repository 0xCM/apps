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