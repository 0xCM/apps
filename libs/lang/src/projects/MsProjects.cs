//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class MsProjects
    {
        const NumericKind Closure = UnsignedInts;

        const string NetSdk = "Microsoft.NET.Sdk";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Property<T> property<T>(Name name, T value)
            => new Property<T>(name, value);

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
                => new ItemGroup(src.Select(x => x as IProjectItem));

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
                => src.ToString();

        public static string format(Property src)
            => string.Format("<{0}>{1}</{0}>", src.Name, src.Value);

        public static string format<T>(Property<T> src)
            => string.Format("<{0}>{1}</{0}>", src.Name, src.Value);
    }
}