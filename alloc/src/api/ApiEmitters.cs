//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiEmitters : AppService<ApiEmitters>
    {
        ApiServices ApiSvc => Service(Wf.ApiServices);

        AppSvcOps AppSvc
            => Service(Wf.AppSvc);

        AppDb AppDb
            => Service(Wf.AppDb);

        public void Emit()
        {
            ApiEmit(ApiSvc.CalcSymLits());
        }

        void ApiEmit(Index<SymLiteralRow> symlits)
            => core.exec(true,
                EmitDataTypes,
                //EmitBitMasks,
                EmitDataFlows,
                EmitEnumList,
                EmitCompilationLits,
                EmitComments,
                EmitParsers,
                EmitApiTables,
                EmitApiCommands,
                () => EmitSymHeap(symlits),
                () => EmitSymLits(symlits)
            );

        void EmitApiCommands()
            => ApiSvc.Emit(ApiSvc.CalcApiCommands());

        void EmitCompilationLits()
            => ApiSvc.Emit(ApiSvc.CalcCompilationLits());

        void EmitComments()
            => ApiSvc.EmitComments();

        void EmitEnumList()
            => ApiSvc.EmitTypeList("api.enums.types", ApiSvc.CalcEnumTypes());

        void EmitDataFlows()
            => ApiSvc.Emit(ApiSvc.CalcDataFlows());

        void EmitDataTypes()
            => ApiSvc.Emit(ApiSvc.CalcDataTypes());

        void EmitSymLits(Index<SymLiteralRow> src)
            => ApiSvc.Emit(src);

        void EmitSymHeap(Index<SymLiteralRow> src)
            => ApiSvc.EmitSymHeap(ApiSvc.CalcSymHeap(src));

        void EmitApiTables()
            => ApiSvc.Emit(ApiSvc.CalcTableDefs());

        void EmitParsers()
        {
            var parsers = Parsers.discover(ApiRuntimeCatalog.Components);
            var targets = parsers.Keys;
            var dst = text.emitter();
            iter(targets, target => dst.AppendLineFormat("parse:string -> {0}", target.DisplayName()));
            AppSvc.FileEmit(dst.Emit(), targets.Count, AppDb.ApiTargets().Path("parsers", FileKind.List));
        }
    }
}