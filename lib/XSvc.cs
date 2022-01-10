//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Svc = Z0;

    using Asm;

    [ApiHost]
    public static partial class XSvc
    {
        [Op]
        public static ApiResolver ApiResolver(this IWfRuntime wf)
            => Z0.ApiResolver.create(wf);

        [Op]
        public static MsilPipe MsilPipe(this IWfRuntime wf)
            => Z0.MsilPipe.create(wf);

        [Op]
        public static TypeParser TypeParser(this IWfRuntime wf)
            => Z0.TypeParser.create(wf);

        [Op]
        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Z0.CmdLineRunner.create(wf);

        [Op]
        public static ScriptRunner ScriptRunner(this IServiceContext context)
            => Z0.ScriptRunner.create(context.EnvPaths);

        [Op]
        public static ScriptRunner ScriptRunner(this IEnvPaths paths)
            => Z0.ScriptRunner.create(paths);

        [Op]
        public static OmniScript OmniScript(this IWfRuntime wf)
            => Z0.OmniScript.create(wf);

        [Op]
        public static Tooling Tooling(this IWfRuntime wf)
            => Svc.Tooling.create(wf);

        [Op]
        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Svc.HexCsvReader.create(wf);

        [Op]
        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Svc.HexCsvWriter.create(wf);

        [Op]
        public static AssetServices Assets(this IWfRuntime wf)
            => AssetServices.create(wf);

        [Op]
        public static CharMapper CharMapper(this IServiceContext context)
            => Svc.CharMapper.create(context);

        [Op]
        public static Symbolism Symbolism(this IWfRuntime wf)
            => Svc.Symbolism.create(wf);

        [Op]
        public static TokenSetEmitter TokenEmitter(this IWfRuntime wf)
            => TokenSetEmitter.create(wf);

        [Op]
        public static AppSettings AppSettings(this IWfRuntime wf)
            => Svc.AppSettings.create(wf);

        public static FileSplitter FileSplitter(this IWfRuntime wf)
            => Svc.FileSplitter.create(wf);

        [Op]
        public static SymServices SymServices(this IWfRuntime wf)
            => Svc.SymServices.create(wf);

        [Op]
        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Svc.HexEmitter.create(wf);

        [Op]
        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Svc.BitfieldServices.create(wf);

        [Op]
        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Svc.ProjectScripts.create(wf);

        [Op]
        public static TableEmitters TableEmitters(this IWfRuntime context)
            => Z0.TableEmitters.create(context);

        [Op]
        public static StringTableGen StringTableGen(this IWfRuntime context)
            => Z0.StringTableGen.create(context);

        [Op]
        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Z0.ApiResProvider.create(wf);

        [Op]
        public static BitMaskServices ApiBitMasks(this IWfRuntime wf)
            => Z0.BitMaskServices.create(wf);

        [Op]
        public static ApiHex ApiHex(this IWfRuntime wf)
            => Z0.ApiHex.create(wf);

        [Op]
        public static ApiCaptureArchive ApiCaptureArchive(this IWfRuntime wf)
            => Z0.ApiCaptureArchive.create(wf);

        [Op]
        public static ApiPackages ApiPackages(this IEnvPaths src)
            => src.PackageRoot();

        [Op]
        public static ApiHexPacks ApiHexPacks(this IWfRuntime wf)
            => Svc.ApiHexPacks.create(wf);

        [Op]
        public static ApiMetadataService ApiMetadata(this IWfRuntime context)
            => Svc.ApiMetadataService.create(context);

        [Op]
        public static ApiComments ApiComments(this IWfRuntime wf)
            => Z0.ApiComments.create(wf);

        [Op]
        public static ApiRuntime ApiRuntime(this IWfRuntime wf)
            => Z0.ApiRuntime.create(wf);

        [Op]
        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Z0.ApiIndexBuilder.create(wf);

        [Op]
        public static ApiAssets ApiAssets(this IWfRuntime wf)
            => Z0.ApiAssets.create(wf);

        [Op]
        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Z0.ApiCatalogs.create(wf);

        [Op]
        public static ApiJit ApiJit(this IWfRuntime wf)
            => Z0.ApiJit.create(wf);

        [Op]
        public static ApiQuery ApiQuery(this IWfRuntime wf)
            => Z0.ApiQuery.create(wf);

        [Op]
        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Z0.MemoryEmitter.create(wf);

        [Op]
        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Z0.ApiPacks.create(wf);

        [Op]
        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Z0.ApiResPackEmitter.create(wf);

        [Op]
        public static AsmVars AsmVars(this IWfRuntime wf)
            => Asm.AsmVars.create(wf);

        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Asm.AsmTables.create(wf);

        [Op]
        public static AsmSourceDocs AsmSourceDocs(this IWfRuntime wf)
            => Asm.AsmSourceDocs.create(wf);

        [Op]
        public static AsmTokens AsmTokens(this IServiceContext context)
            => Asm.AsmTokens.create(context);

        [Op]
        public static AsmSymbols AsmSymbols(this IServiceContext context)
            => Asm.AsmSymbols.create();

        [Op]
        public static AsmRegSets AsmRegSets(this IWfRuntime context)
            => Asm.AsmRegSets.create(context);

        [Op]
        public static AsmEtl AsmEtl(this IWfRuntime context)
            => Asm.AsmEtl.create(context);
    }
}