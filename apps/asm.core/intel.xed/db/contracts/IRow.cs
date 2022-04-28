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
        public interface IRow : IKeyed
        {

        }

        [Free]
        public interface IRow<T> : IRow, IKeyed<T>
            where T : IRow<T>
        {

        }
    }
}