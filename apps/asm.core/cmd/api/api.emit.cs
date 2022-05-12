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

        [CmdOp("api/emit/flows")]
        Outcome EmitDataFlowSpecs(CmdArgs args)
        {
            ApiSvc.EmitDataFlows();
            return true;
        }

        [CmdOp("api/emit/literals")]
        Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            ApiSvc.EmitApiLiterals();
            return result;
        }

        [CmdOp("api/parsers")]
        Outcome RevealParsers(CmdArgs args)
        {
            var parsers = Parsers.discover(ApiRuntimeCatalog.Components, out var log);
            var targets = parsers.Keys;
            foreach(var target in targets)
                Write(string.Format("parse:string -> {0}", target.DisplayName()));

            return true;
        }

        [CmdOp("api/emit/enum")]
        Outcome EmitApiEnums(CmdArgs args)
        {
            ApiSvc.EmitEnumList();
            return true;
        }

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            ApiSvc.EmitBitMasks();
            ApiSvc.EmitDataTypes();
            ApiSvc.EmitEnumList();
            ApiSvc.EmitApiMd();
            //EmitAsmDocs();
            ApiSvc.EmitDataFlows();
            ApiSvc.EmitApiLiterals();
            ApiSvc.EmitComments();
            return true;
        }

        [CmdOp("api/emit/types")]
        Outcome EmitDataTypes(CmdArgs args)
        {
            ApiSvc.EmitDataTypes();
           return true;
        }

        [CmdOp("api/emit/comments")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            ApiSvc.EmitApiMd();
            return true;
        }

   }
}