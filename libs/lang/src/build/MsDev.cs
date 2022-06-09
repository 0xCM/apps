//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Build.Construction;

    using MsBC = Microsoft.Build.Construction;

    using static Root;
    using static core;
    using static MsProjects;

    [ApiHost]
    public partial class MsDev
    {
        public readonly struct MsBuildImports
        {
            public Assembly MsBuildFramework
                => typeof(Microsoft.Build.Framework.BuildEngineResult).Assembly;

            public Assembly MsBuildTasks
                => typeof(Microsoft.Build.Tasks.AssignCulture).Assembly;

            public Assembly MsBuildUtilities
                => typeof(Microsoft.Build.Utilities.MuxLogger).Assembly;
        }

        [Op]
        public static Project resbytes()
        {
            var itemBuffer = alloc<IProjectItem>(4);
            var items = span(itemBuffer);
            seek(items,0) = MsProjects.resource("asm/**/*.asm");
            seek(items,1) = MsProjects.resource("docs/**/*.csv");
            seek(items,2) = MsProjects.resource("index/**/*.csv");
            seek(items,3) = MsProjects.resource("metadata/**/*.csv");

            var props = alloc<IProjectProperty>(4);
            seek(props,0) = MsProjects.library();
            seek(props,1) = MsProjects.netcoreapp(n3);

            return MsProjects.project("z0.res", MsProjects.netsdk(), default, MsProjects.items(itemBuffer));
        }

        public static ref Solution parse(in SlnFile src, out Solution dst)
        {
            dst = new Solution();
            var data = MsBC.SolutionFile.Parse(src.Name);
            var projects = data.ProjectsInOrder;
            var count = projects.Count;
            var buffer = alloc<SlnProject>(count);
            dst.Path = src;
            dst.Projects = buffer;

            ref var dstProject = ref first(span(buffer));
            for(var i=0; i<count; i++)
            {
                var srcProject = projects[i];
                dstProject = ref seek(dstProject,i);
                dstProject.Path = FS.path(srcProject.AbsolutePath);
                dstProject.ProjectName = srcProject.ProjectName;
                dstProject.ProjectGuid = Guid.Parse(srcProject.ProjectGuid);
                dstProject.Dependencies = srcProject.Dependencies.Map(x => Guid.Parse(x));
                var configs = @readonly(srcProject.ProjectConfigurations.Values.Array());
                var kConfig = configs.Length;
                dstProject.Configurations = sys.alloc<SlnProjectConfig>(kConfig);
                var dstConfigs = dstProject.Configurations.Edit;
                for(var j=0; j<kConfig; j++)
                    define(skip(configs,i), ref seek(dstConfigs, j));

            }

            return ref dst;
        }

        public static ref SlnProjectConfig define(in ProjectConfigurationInSolution src, ref SlnProjectConfig dst)
        {
            dst.Build = src.IncludeInBuild;
            dst.FullName = src.FullName;
            dst.SimpleName = src.ConfigurationName;
            dst.Platform = src.PlatformName;
            return ref dst;
        }

        public static BuildProjectCmd BuildCmd(IEnvPaths src, WsVars vars)
        {
            var dst = new BuildProjectCmd();
            dst.Verbosity = BuildLogVerbosity.detailed;
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = 6;
            dst.LogFile = BuildPaths.log(src, vars);
            dst.ProjectPath = BuildPaths.project(src,vars);
            dst.SolutionPath = BuildPaths.soulution(src,vars);
            return dst;
        }

        public static string identifier(in BuildProjectCmd src)
            => string.Format("{0}_{1}", BuildProjectCmd.CmdName, src.SolutionPath.IsNonEmpty ? src.SolutionPath.FileName.Format() : src.ProjectPath.FileName.Format());

        public static Outcome<FS.FilePath> save(BuildProjectCmd src, FS.FolderPath dst)
        {
            var path = dst + FS.file(identifier(src), FS.Cmd);
            var result = path.Save(format(src));
            if(result)
                return path;
            else
                return result;
        }

        public static string format(in BuildProjectCmd src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        static void render(in BuildProjectCmd src, ITextBuffer dst)
        {
            const string PropertySpec = "/p:{0}={1}";

            const string Flag = "-{0}";

            const string OptionValue = "-{0}:{1}";

            const string QuotedOptionAssign ="-{0}:{1}=" + RP.QuotedSlot2;

            const string QuotedPropertySpec = "/p:{0}=" + RP.QuotedSlot1;

            dst.Append("dotnet build");

            dst.AppendSpace();
            dst.Append(src.SolutionPath.Format(PathSeparator.BS));

            dst.AppendSpace();
            dst.AppendFormat(PropertySpec, nameof(src.Configuration), src.Configuration);

            dst.AppendSpace();
            dst.AppendFormat(QuotedPropertySpec, nameof(src.Platform), src.Platform);

            if(src.LogFile.IsNonEmpty)
            {
                dst.AppendSpace();
                dst.AppendFormat(Flag, "fl");
                dst.AppendSpace();
                dst.AppendFormat(QuotedOptionAssign, "flp", nameof(src.LogFile), src.LogFile.Format(PathSeparator.BS));
                if(src.Verbosity != 0)
                    dst.AppendFormat(";{0}={1} ","verbosity", src.Verbosity);
            }

            if(src.MaxCpuCount != 0)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, nameof(src.MaxCpuCount), src.MaxCpuCount);
            }

            if(src.Graph)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, "graph", src.Graph);
            }
        }
    }
}