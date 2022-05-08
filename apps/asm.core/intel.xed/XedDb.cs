//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
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

        public void EmitLayouts()
            => Emit(CalcLayouts(Rules.CalcInstPatterns()));

        void Emit(InstLayouts src)
        {
            AppSvc.FileEmit(src.Format(), 0, Paths.InstTarget("layouts.vectors", FileKind.Csv));
            AppSvc.TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.InstTable<InstLayoutRecord>());
        }

        public InstLayouts CalcLayouts(Index<InstPattern> src)
            => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(src));

        public LayoutVectors CalcLayoutVectors(InstLayouts src)
            => Data(nameof(CalcLayoutVectors), () => LayoutCalcs.vectors(src));

        AppServices AppSvc => Service(Wf.AppServices);

        RuleCells RuleCells => Rules.CalcRuleCells(RuleTables);

        bool PllExec => true;

        public XedRules Rules => Xed.Rules;

        RuleTables RuleTables => Rules.CalcRuleTables();
    }
}