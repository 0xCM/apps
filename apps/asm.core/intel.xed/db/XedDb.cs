//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MemDb;

    using static XedRules;

    public partial class XedDb : AppService<XedDb>
    {
        static MemDb MemDb;

        static XedDb()
        {
            MemDb = MemDb.open();
        }

        new XedPaths Paths => Service(Wf.XedPaths);

        public ref readonly DbSvc Services => ref MemDb.Services;

        ref readonly DbRender Render => ref Services.ObjRender;

        RuleTables RuleTables => Rules.CalcRuleTables();

        RuleCells RuleCells => Rules.CalcRuleCells(RuleTables);

        bool PllExec => AppData.get().PllExec();

        public XedRules Rules => Service(Wf.XedRules);

        public DbViews Views
        {
            [MethodImpl(Inline)]
            get => new DbViews(this);
        }
    }
}