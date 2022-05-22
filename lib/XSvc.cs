//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            => Z0.Tooling.create(wf);

        [Op]
        public static AssetServices Assets(this IWfRuntime wf)
            => AssetServices.create(wf);

        [Op]
        public static CharMapper CharMapper(this IServiceContext context)
            => Z0.CharMapper.create(context);

        [Op]
        public static AppSettings AppSettings(this IWfRuntime wf)
            => Z0.AppSettings.create(wf);

        public static FileSplitter FileSplitter(this IWfRuntime wf)
            => Z0.FileSplitter.create(wf);

        [Op]
        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Z0.ApiResProvider.create(wf);

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
            => Z0.ApiHexPacks.create(wf);

        [Op]
        public static ApiMetadataService ApiMetadata(this IWfRuntime context)
            => Z0.ApiMetadataService.create(context);


        [Op]
        public static ApiRuntime ApiRuntime(this IWfRuntime wf)
            => Z0.ApiRuntime.create(wf);

        [Op]
        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Z0.ApiIndexBuilder.create(wf);

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

    }
}