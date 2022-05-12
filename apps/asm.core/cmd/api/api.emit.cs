//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        ApiServices ApiSvc => Service(Wf.ApiServices);

        [CmdOp("api/parsers")]
        Outcome RevealParsers(CmdArgs args)
        {
            var parsers = Parsers.discover(ApiRuntimeCatalog.Components, out var log);
            var targets = parsers.Keys;
            foreach(var target in targets)
                Write(string.Format("parse:string -> {0}", target.DisplayName()));

            return true;
        }

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            ApiSvc.EmitBitMasks();
            ApiSvc.Emit(ApiSvc.CalcDataTypes());
            var lits = ApiSvc.CalcSymLits();
            ApiSvc.Emit(lits);

            var heap = ApiSvc.CalcSymHeap(lits);
            ApiSvc.Emit(heap);

            ApiSvc.EmitEnumList();
            ApiSvc.EmitApiMd();
            ApiSvc.Emit(ApiSvc.CalcDataFlows());
            ApiSvc.Emit(ApiSvc.CalcCompilationLits());
            ApiSvc.EmitComments();
            return true;
        }
   }
}