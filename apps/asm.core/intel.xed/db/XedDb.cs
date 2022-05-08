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
        new XedPaths Paths => Xed.Paths;

        XedRuntime Xed;

        public XedDb With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        AppServices AppServices => Service(Wf.AppServices);

        RuleCells RuleCells => Rules.CalcRuleCells(RuleTables);

        bool PllExec => true;

        public XedRules Rules => Xed.Rules;

        RuleTables RuleTables => Rules.CalcRuleTables();

        public DbViews Views
        {
            [MethodImpl(Inline)]
            get => new DbViews(this);
        }
    }
}