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
        public static DbSvc services(IWfRuntime wf)
            => service(DbSvc.create);

        public void EmitArtifacts()
        {
            exec(PllExec,
                EmitRuleSchema,
                EmitTypeTables
            );
        }

        new XedPaths Paths => Service(Wf.XedPaths);

        public DbSvc DbServices => Service(() => services(Wf));

        RuleTables RuleTables => Rules.CalcRuleTables();

        RuleCells RuleCells => Rules.CalcRuleCells(RuleTables);

        bool PllExec => AppData.get().PllExec();

        public XedRules Rules => Service(Wf.XedRules);

        public DbObjects Objects => DbServices.Objects;

        public DbRender Render => DbServices.ObjRender;

        public DbSchema Schema => DbServices.Schema;
    }
}