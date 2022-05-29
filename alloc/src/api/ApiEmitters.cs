//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiEmitters : AppService<ApiEmitters>
    {
        Heaps Heaps => Wf.Heaps();

        ApiMd ApiMd => Wf.ApiMetadata();

        AppSvcOps AppSvc
            => Service(Wf.AppSvc);

        AppDb AppDb
            => Service(Wf.AppDb);

        public void Emit()
        {
            ApiMd.EmitDatasets();
            Heaps.Emit(Heaps.symbols(ApiMd.SymLits));
        }

        // void ApiEmit(Index<SymLiteralRow> symlits)
        //     => core.exec(true,
        //         EmitDataFlows,
        //         EmitTypeLists,
        //         EmitCompilationLits,
        //         EmitDataTypes,
        //         EmitComments,
        //         EmitParsers,
        //         EmitApiTables,
        //         EmitApiCommands,
        //         EmitApiBitMasks,
        //         () => EmitSymLits(symlits)
        //     );

        // void EmitApiCommands()
        //     => ApiMd.Emit(ApiMd.ApiCommands);

        // void EmitCompilationLits()
        //     => ApiMd.Emit(ApiMd.ApiLiterals);

        // void EmitComments()
        //     => ApiMd.EmitComments();

        // void EmitApiBitMasks()
        //     => ApiMd.Emit(ApiMd.ApiBitMasks);

        // void EmitTypeLists()
        // {
        //     ApiMd.EmitTypeList("api.types.enums", ApiMd.EnumTypes);
        //     ApiMd.EmitTypeList("api.types.records", ApiMd.ApiTableTypes);
        // }

        // void EmitDataFlows()
        //     => ApiMd.Emit(ApiMd.DataFlows);

        // void EmitDataTypes()
        //     => ApiMd.Emit(ApiMd.DataTypes);

        // void EmitApiTables()
        //     => ApiMd.Emit(ApiMd.ApiTableFields);

        // void EmitSymLits(Index<SymLiteralRow> src)
        //     => ApiMd.Emit(src);

        // void EmitSymHeap(Index<SymLiteralRow> src)
        //     => Heaps.Emit(Heaps.symbols(src));

        // void EmitParsers()
        // {
        //     var parsers = Parsers.discover(ApiRuntimeCatalog.Components);
        //     var targets = parsers.Keys;
        //     var dst = text.emitter();
        //     iter(targets, target => dst.AppendLineFormat("parse:string -> {0}", target.DisplayName()));
        //     AppSvc.FileEmit(dst.Emit(), targets.Count, AppDb.ApiTargets().Path("parsers", FileKind.List));
        // }
    }
}