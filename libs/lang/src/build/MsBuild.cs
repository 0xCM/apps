//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;
    using D = Microsoft.Build.Definition;
    using C = Microsoft.Build.Construction;
    using B = Build;

    using static core;

    using static Build;
    
    [ApiHost]
    public partial class BuildSvc : WfSvc<BuildSvc>
    {
        const NumericKind Closure = UnsignedInts;

        ConcurrentDictionary<FS.FilePath, ProjectSpec> ProjectLookup = new();

        [MethodImpl(Inline), Op]
        internal static B.Property property(E.ProjectProperty src)
            => new B.Property(src);

        public ProjectSpec LoadProject(FS.FilePath src)
            => ProjectLookup.GetOrAdd(src, project);

        static ProjectSpec project(FS.FilePath src)
            => new(E.Project.FromFile(src.Name, new D.ProjectOptions {}));

        [MethodImpl(Inline), Op]
        public static Sdk sdk(string name)
            => new Sdk(name);

        [MethodImpl(Inline), Op]
        public static PropertyGroup properties(Property[] src)
            => new PropertyGroup(src);

        [MethodImpl(Inline), Op]
        internal static ProjectItem item(E.ProjectItem src)
            => new ProjectItem(src);

        [MethodImpl(Inline), Op]
        public static TargetFramework framework(string value)
            => new TargetFramework(value);

        [MethodImpl(Inline), Op]
        public static Property<T> property<T>(T src)
            where T : struct, IProjectProperty<T>
                => new Property<T>(src);

        public static BuildProjectCmd BuildProjectCmd(FS.FilePath src)
        {
            var dst = new BuildProjectCmd();
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = 6;
            dst.Verbosity = BuildLogVerbosity.detailed;
            dst.ProjectPath = src;
            return dst;
        }

        public static string format(in BuildProjectCmd src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        public Solution sln(FS.FilePath src)
        {
            var sln = new Solution();
            var data = C.SolutionFile.Parse(src.Name);
            var projects = data.ProjectsInOrder.Index().Where(p => p != null);
            var count = projects.Count;
            var dst = alloc<SlnProject>(count);
            sln.Path = src;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref projects[i];
                ref var project = ref seek(dst,i);
                project.Path = FS.path(input?.AbsolutePath ?? EmptyString);
                project.ProjectName = input?.ProjectName ?? EmptyString;
                project.ProjectGuid = Guid.Parse(input.ProjectGuid);
                if(input.Dependencies != null)
                    project.Dependencies = input.Dependencies.Map(x => Guid.Parse(x));
                else
                    project.Dependencies = sys.empty<Guid>();
                if(input.ProjectConfigurations != null)
                {
                    var configs = input.ProjectConfigurations.Values.Index();
                    project.Configurations = sys.alloc<SlnProjectConfig>(configs.Count);

                    for(var j=0; j<configs.Count; j++)
                        define(configs[i], ref project.Configurations[j]);
                }
                else
                    project.Configurations = sys.empty<SlnProjectConfig>();
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

        [Op]
        public static ProjectSpec resbytes()
        {
            var itemBuffer = alloc<IProjectItem>(4);
            var items = span(itemBuffer);
            // seek(items,0) = BuildSvc.resource("asm/**/*.asm");
            // seek(items,1) = BuildSvc.resource("docs/**/*.csv");
            // seek(items,2) = BuildSvc.resource("index/**/*.csv");
            // seek(items,3) = BuildSvc.resource("metadata/**/*.csv");
            var props = alloc<IProjectProperty>(4);
            return default;
        }
    }
}