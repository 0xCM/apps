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

        IMemDb _Store;

        XedRuntime Xed;

        public XedDb With(XedRuntime xed)
        {
            Xed = xed;
            _Store = MemDb.open(xed.AppDb.Targets("memdb").Path("runtime", FileKind.Bin), new Gb(1));
            return this;
        }

        public IMemDb Store
        {
            [MethodImpl(Inline)]
            get => _Store;
        }

        ref readonly CellTables CellTables => ref Xed.Views.CellTables;

        ref readonly Index<InstPattern> Patterns => ref Xed.Views.Patterns;

        public void EmitLayouts()
            => Emit(CalcLayouts(Patterns));

        void Emit(InstLayouts src)
        {
            AppSvc.FileEmit(src.Format(), 0, Paths.InstTarget("layouts.vectors", FileKind.Csv));
            AppSvc.TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.InstTable<InstLayoutRecord>());
        }

        public InstLayouts CalcLayouts(Index<InstPattern> src)
            => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(src));

        public LayoutVectors CalcLayoutVectors(InstLayouts src)
            => Data(nameof(CalcLayoutVectors), () => LayoutCalcs.vectors(src));

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        bool PllExec => true;

        public XedRules Rules => Xed.Rules;
    }
}