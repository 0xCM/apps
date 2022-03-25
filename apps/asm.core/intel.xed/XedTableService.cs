//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedTableService : GlobalService<XedTableService,XedTables>
    {
        protected override XedTableService Init(out XedTables state)
        {
            state = new ();
            return this;
        }

        public XedTables Data
        {
            [MethodImpl(Inline)]
            get => State;
        }
    }
}