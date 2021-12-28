//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Svc = Z0;

    using Asm;

    partial class XSvc
    {
        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Asm.AsmTables.create(wf);

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
    }
}