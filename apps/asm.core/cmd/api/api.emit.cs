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

        void EmitApiLiterals()
            => TableEmit(ApiLiterals().View, ProjectDb.ApiTablePath<CompilationLiteral>());

        void EmitDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.ProjectDb().Api() + Tables.filename<DataTypeRecord>());

        void EmitApiComments()
            => ApiEmitters.EmitApiComments();

        void EmitApiMd()
            => ApiComments.EmitMarkdownDocs(new string[]{
                nameof(vpack),
                nameof(vmask),
                nameof(cpu),
                nameof(gcpu),
                nameof(BitMasks),
                nameof(BitMaskLiterals),
                });

        void EmitAsmDocs()
            => AsmDocs.Emit();

        void EmitBitMasks()
            => ApiBitMasks.Emit();


        [CmdOp("api/emit/flowspecs")]
        Outcome EmitDataFlowSpecs(CmdArgs args)
        {
            ApiEmitters.EmitDataFlowSpecs();
            return true;
        }

        [CmdOp("api/emit/literals")]
        Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            EmitApiLiterals();
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
            ApiEmitters.EmitApiEnums();
            return true;
        }

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            EmitBitMasks();
            EmitDataTypes();
            EmitApiMd();
            EmitAsmDocs();
            return true;
        }

        [CmdOp("api/emit/types")]
        Outcome EmitDataTypes(CmdArgs args)
        {
            EmitDataTypes();
           return true;
        }

        [CmdOp("api/emit/comments")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            EmitApiMd();
            return true;
        }

        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitAsmDocs();
            return true;
        }

        [CmdOp("api/check/classifiers")]
        Outcome CheckClassifiers(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var count = classifier.ClassCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref classifier[i];
                Write(string.Format("{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}", c.Ordinal, c.ClassName, c.Identifier, c.Symbol, c.Value));
            }

            return true;
        }
    }
}