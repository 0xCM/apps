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

    partial class XTend
    {
        public static XedTables XedTables(this IWfRuntime wf)
            => Z0.XedTables.create(wf);

    }
}