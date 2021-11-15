//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.Build.Construction;

    using MsBC = Microsoft.Build.Construction;

    using static Root;
    using static core;
    using static ProjectModel;

    [ApiHost]
    public readonly partial struct Dev
    {
        const string NetSdk = "Microsoft.NET.Sdk";

        [Op]
        public static Project resbytes()
        {
            var itemBuffer = alloc<ProjectItem>(4);
            var items = span(itemBuffer);
            seek(items,0) = resource("asm/**/*.asm");
            seek(items,1) = resource("docs/**/*.csv");
            seek(items,2) = resource("index/**/*.csv");
            seek(items,3) = resource("metadata/**/*.csv");

            var propBuffer = alloc<Property>(4);
            var props = span(propBuffer);
            seek(props,0) = library();
            seek(props,1) = netcoreapp(n3);

            return project("z0.res", netsdk(), default, itemBuffer);
        }

        [MethodImpl(Inline), Op]
        public static FS.FileName filename(in Project src, string type)
            => FS.file(src.Name, type);

        [Op]
        public static void save(in Project src, string type, FS.FolderPath dst)
            => (dst + filename(src,type)).Overwrite(src.Format());

        [MethodImpl(Inline), Op]
        public static Sdk sdk(string name)
            => new Sdk(name);

        [MethodImpl(Inline), Op]
        public static Sdk netsdk()
            => new Sdk(NetSdk);

        [MethodImpl(Inline), Op]
        public static Project project(string name, Sdk sdk, PropertyGroup props, ItemGroup items)
            => new Project(name, sdk, array(props), array(items));

        [MethodImpl(Inline), Op]
        public static Project project(string name, Sdk sdk, PropertyGroup[] props, ItemGroup[] items)
            => new Project(name, sdk, props, items);

        [MethodImpl(Inline), Op]
        public static Project project(string name, Sdk sdk, ProjectProperty[] props, ProjectItem[] _items)
            => project(name, sdk, properties(props), items(_items));

        [MethodImpl(Inline), Op]
        public static OutputType library()
            => new OutputType(OutputTypes.Library);

        [MethodImpl(Inline), Op]
        public static OutputType exe()
            => new OutputType(OutputTypes.Exe);

        [MethodImpl(Inline), Op]
        public static TargetFramework netcoreapp(N3 major)
            => TargetFrameworks.netcoreapp3_0;

        [MethodImpl(Inline), Op]
        public static TargetFramework netcoreapp(N3 major, N1 minor)
            => TargetFrameworks.netcoreapp3_1;

        [MethodImpl(Inline), Op]
        public static PropertyGroup properties(Property[] src)
            => new PropertyGroup(src);

        [MethodImpl(Inline), Op]
        public static PropertyGroup properties<T>(T[] src)
            where T : IProjectProperty
                => new PropertyGroup(src.Map(x => new Property(x.Name, x.Value)));

        [MethodImpl(Inline), Op]
        public static ItemGroup items<T>(T[] src)
            where T : IProjectItem
                => new ItemGroup(src.Map(x => new ProjectItem(x)));

        [MethodImpl(Inline), Op]
        public static ItemGroup items(ProjectItem[] src)
            => new ItemGroup(src);

        [MethodImpl(Inline), Op]
        public static ProjectItem<EmbeddedResourceSpec> resource(string include)
            => new EmbeddedResourceSpec(include);

        [MethodImpl(Inline), Op]
        public static TargetFramework framework(string value)
            => new TargetFramework(value);

        [MethodImpl(Inline)]
        public static ProjectItem<T> item<T>(T src)
            where T : struct, IProjectItem<T>
                => new ProjectItem<T>(src);

        [MethodImpl(Inline), Op]
        public static ProjectProperty<T> property<T>(T src)
            where T : struct, IProjectProperty<T>
                => new ProjectProperty<T>(src);

        [MethodImpl(Inline)]
        public static string format<T>(T src)
            where T : struct, IProjectElement<T>
                => src.Format();

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
                    project(skip(configs,i), ref seek(dstConfigs, j));

            }

            return ref dst;
        }

        public static ref SlnProjectConfig project(in ProjectConfigurationInSolution src, ref SlnProjectConfig dst)
        {
            dst.Build = src.IncludeInBuild;
            dst.FullName = src.FullName;
            dst.SimpleName = src.ConfigurationName;
            dst.Platform = src.PlatformName;
            return ref dst;
        }
    }
}