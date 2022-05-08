//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedTables : GlobalService<XedTables,object>
    {
        protected override XedTables Init(out object state)
        {
            state = new();
            return this;
        }
    }
}