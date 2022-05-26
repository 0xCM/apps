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
        public static MsilPipe MsilPipe(this IWfRuntime wf)
            => Z0.MsilPipe.create(wf);

        [Op]
        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Z0.CmdLineRunner.create(wf);

        [Op]
        public static ScriptRunner ScriptRunner(this IServiceContext context)
            => Z0.ScriptRunner.create(context.EnvPaths);

        [Op]
        public static OmniScript OmniScript(this IWfRuntime wf)
            => Z0.OmniScript.create(wf);

        [Op]
        public static AppSettings AppSettings(this IWfRuntime wf)
            => Z0.AppSettings.create(wf);

        [Op]
        public static ApiHex ApiHex(this IWfRuntime wf)
            => Z0.ApiHex.create(wf);

        [Op]
        public static ApiRuntime ApiRuntime(this IWfRuntime wf)
            => Z0.ApiRuntime.create(wf);

        [Op]
        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Z0.ApiIndexBuilder.create(wf);

        [Op]
        public static ApiJit ApiJit(this IWfRuntime wf)
            => Z0.ApiJit.create(wf);

        [Op]
        public static ApiQuery ApiQuery(this IWfRuntime wf)
            => Z0.ApiQuery.create(wf);

        [Op]
        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Z0.ApiPacks.create(wf);
    }
}