//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;
    using D = Microsoft.Build.Definition;
    using C = Microsoft.Build.Construction;

    using static core;

    [ApiHost]
    public partial class MsBuild
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        internal static Property property(E.ProjectProperty src)
            => new Property(src);

        readonly struct MsBuildImports
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
            seek(items,0) = MsBuild.resource("asm/**/*.asm");
            seek(items,1) = MsBuild.resource("docs/**/*.csv");
            seek(items,2) = MsBuild.resource("index/**/*.csv");
            seek(items,3) = MsBuild.resource("metadata/**/*.csv");
            var props = alloc<IProjectProperty>(4);
            // seek(props,0) = MsBuild.library();
            // seek(props,1) = MsBuild.netcoreapp(n3);

            return default;

            //return MsProjects.project("z0.res", MsProjects.netsdk(), default, MsProjects.items(itemBuffer));
        }

        public static BuildProjectCmd BuildProjectCmd(FS.FilePath src)
        {
            var dst = new BuildProjectCmd();
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = 6;
            dst.Verbosity = BuildLogVerbosity.detailed;
            dst.ProjectPath = src;
            // dst.LogFile = BuildPaths.log(src, vars);
            // dst.ProjectPath = BuildPaths.project(src,vars);
            // dst.SolutionPath = BuildPaths.soulution(src,vars);
            return dst;
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

            const string QuotedOptionAssign ="-{0}:{1}=" + RpOps.QuotedSlot2;

            const string QuotedPropertySpec = "/p:{0}=" + RpOps.QuotedSlot1;

            dst.Append("dotnet build");

            dst.AppendSpace();
            dst.Append(src.ProjectPath.Format(PathSeparator.BS));

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

        public static Project project(FS.FilePath src)
            => new(E.Project.FromFile(src.Name, new D.ProjectOptions {}));

        public static Solution sln(FS.FilePath src)
        {
            var sln = new Solution();
            var data = C.SolutionFile.Parse(src.Name);
            var projects = data.ProjectsInOrder;
            var count = projects.Count;
            var dst = alloc<SlnProject>(count);
            sln.Path = src;
            sln.Projects = dst;
            for(var i=0; i<count; i++)
            {
                var input = projects[i];
                ref var output = ref seek(dst,i);
                output.Path = FS.path(input.AbsolutePath);
                output.ProjectName = input.ProjectName;
                output.ProjectGuid = Guid.Parse(input.ProjectGuid);
                output.Dependencies = input.Dependencies.Map(x => Guid.Parse(x));
                var configs = @readonly(input.ProjectConfigurations.Values.Array());
                var kConfig = configs.Length;
                output.Configurations = sys.alloc<SlnProjectConfig>(kConfig);
                var dstConfigs = output.Configurations.Edit;
                for(var j=0; j<kConfig; j++)
                    define(skip(configs,i), ref seek(dstConfigs, j));
            }

            return sln;
        }

        static ref SlnProjectConfig define(in C.ProjectConfigurationInSolution src, ref SlnProjectConfig dst)
        {
            dst.Build = src.IncludeInBuild;
            dst.FullName = src.FullName;
            dst.SimpleName = src.ConfigurationName;
            dst.Platform = src.PlatformName;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static Sdk sdk(string name)
            => new Sdk(name);

        [MethodImpl(Inline), Op]
        public static PropertyGroup properties(Property[] src)
            => new PropertyGroup(src);

        [MethodImpl(Inline), Op]
        public static ItemGroup items(ProjectItem[] src)
            => new ItemGroup(src);

        [MethodImpl(Inline), Op]
        public static EmbeddedResourceSpec resource(string include)
            => new EmbeddedResourceSpec(include);

        [MethodImpl(Inline), Op]
        public static TargetFramework framework(string value)
            => new TargetFramework(value);

        [MethodImpl(Inline), Op]
        public static ProjectProperty<T> property<T>(T src)
            where T : struct, IProjectProperty<T>
                => new ProjectProperty<T>(src);
    }
}