//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Svc = Z0;

    using Asm;

    [ApiHost]
    public partial class XSvc
    {
        [Op]
        public static TypeParser TypeParser(this IWfRuntime wf)
            => Svc.TypeParser.create(wf);

        [Op]
        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Svc.CmdLineRunner.create(wf);

        [Op]
        public static ScriptRunner ScriptRunner(this IServiceContext context)
            => Svc.ScriptRunner.create(context.EnvPaths);

        [Op]
        public static ScriptRunner ScriptRunner(this IEnvPaths paths)
            => Svc.ScriptRunner.create(paths);

        [Op]
        public static OmniScript OmniScript(this IWfRuntime wf)
            => Svc.OmniScript.create(wf);

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
            => Svc.TableEmitters.create(context);

        [Op]
        public static StringTableGen StringTableGen(this IWfRuntime context)
            => Svc.StringTableGen.create(context);

        [Op]
        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Svc.ApiResProvider.create(wf);

        [Op]
        public static BitMaskServices ApiBitMasks(this IWfRuntime wf)
            => Svc.BitMaskServices.create(wf);

        [Op]
        public static ApiHex ApiHex(this IWfRuntime wf)
            => Svc.ApiHex.create(wf);

        [Op]
        public static ApiCaptureArchive ApiCaptureArchive(this IWfRuntime wf)
            => Svc.ApiCaptureArchive.create(wf);

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
            => Svc.ApiComments.create(wf);

        [Op]
        public static ApiRuntime ApiRuntime(this IWfRuntime wf)
            => Svc.ApiRuntime.create(wf);

        /// <summary>
        /// Closes generic operations over the set of primal types that each operation supports
        /// </summary>
        /// <param name="generics">Metadata for generic operations</param>
        [Op]
        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Svc.ApiIndexBuilder.create(wf);

        [Op]
        public static ApiAssets ApiAssets(this IWfRuntime wf)
            => Svc.ApiAssets.create(wf);

        [Op]
        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Svc.ApiCatalogs.create(wf);

        [Op]
        public static ApiJit ApiJit(this IWfRuntime wf)
            => Svc.ApiJit.create(wf);

        [Op]
        public static ApiQuery ApiQuery(this IWfRuntime wf)
            => Svc.ApiQuery.create(wf);

        [Op]
        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Svc.MemoryEmitter.create(wf);

        [Op]
        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Svc.ApiPacks.create(wf);

        [Op]
        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Svc.ApiResPackEmitter.create(wf);
    }
}