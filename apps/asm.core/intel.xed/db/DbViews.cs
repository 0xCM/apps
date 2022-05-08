//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static MemDb;

    partial class XedDb
    {
        public readonly struct DbViews
        {
            readonly XedDb Db;

            [MethodImpl(Inline)]
            public DbViews(XedDb src)
            {
                Db = src;
            }
        }
    }
}