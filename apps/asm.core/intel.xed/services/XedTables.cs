//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedTables : GlobalService<XedTables,XedLookups>
    {
        protected override XedTables Init(out XedLookups state)
        {
            state = XedLookups.Data;
            return this;
        }

        public XedLookups Data
        {
            [MethodImpl(Inline)]
            get => State;
        }
    }
}