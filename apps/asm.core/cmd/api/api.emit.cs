//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using L = LiteralProvider;

    partial class AsmCoreCmd
    {
        ApiEmitters ApiEmitters => Service(Wf.ApiEmitters);

        ApiAssets ApiAssets => Service(Wf.ApiAssets);

        Index<CompilationLiteral> ApiLiterals()
            => Data(nameof(ApiLiterals), () => L.CompilationLiterals(ApiRuntimeCatalog.Components));

        [CmdOp("api/emit/flows")]
        Outcome EmitDataFlowSpecs(CmdArgs args)
        {
            ApiEmitters.EmitDataFlowSpecs();
            return true;
        }

        [CmdOp("api/emit/literals")]
        Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            ApiEmitters.EmitApiLiterals();
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
            ApiEmitters.EmitEnumList();
            return true;
        }

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            ApiEmitters.EmitBitMasks();
            ApiEmitters.EmitDataTypes();
            ApiEmitters.EmitEnumList();
            ApiEmitters.EmitApiMd();
            ApiEmitters.EmitAsmDocs();
            ApiEmitters.EmitDataFlowSpecs();
            ApiEmitters.EmitApiLiterals();
            ApiEmitters.EmitApiComments();
            return true;
        }

        [CmdOp("api/emit/types")]
        Outcome EmitDataTypes(CmdArgs args)
        {
            ApiEmitters.EmitDataTypes();
           return true;
        }

        [CmdOp("api/emit/comments")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            ApiEmitters.EmitApiMd();
            return true;
        }

        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            ApiEmitters.EmitAsmDocs();
            return true;
        }
   }
}