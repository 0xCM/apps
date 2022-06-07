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
            var itemBuffer = alloc<ProjectItem>(4);
            var items = span(itemBuffer);
            seek(items,0) = MsProjects.resource("asm/**/*.asm");
            seek(items,1) = MsProjects.resource("docs/**/*.csv");
            seek(items,2) = MsProjects.resource("index/**/*.csv");
            seek(items,3) = MsProjects.resource("metadata/**/*.csv");

            var props = alloc<Property>(4);
            seek(props,0) = MsProjects.library();
            seek(props,1) = MsProjects.netcoreapp(n3);

            return MsProjects.project("z0.res", MsProjects.netsdk(), default, itemBuffer);
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


        public static BuildProjectCmd BuildCmd(IEnvPaths src, BuildCmdVars vars)
        {
            var dst = new BuildProjectCmd();
            dst.Verbosity = BuildLogVerbosity.detailed;
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = 6;
            dst.LogFile = src.LogPath(vars);
            dst.ProjectPath = src.ProjectPath(vars);
            dst.SolutionPath = src.SolutionPath(vars);
            return dst;
        }
    }
}