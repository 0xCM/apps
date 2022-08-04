//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Loader;
    using System.Linq;

    public class PartLoadContext : AssemblyLoadContext, IDisposable
    {
        public static PartLoadContext create(Assembly src)
            => new PartLoadContext(src.Path());

        public static PartLoadContext create()
            => new PartLoadContext(ExecutingPart.Component.Path());

        public static Assembly from(AssemblyLoadContext context, FS.FilePath src)
            => context.LoadFromAssemblyPath(src.Name);

        public static Index<Assembly> deps(AssemblyLoadContext context, Assembly src)
            => load(context, src, src.Path().FolderPath).Distinct().Index();

        public static IEnumerable<Assembly> load(AssemblyLoadContext context, Assembly src, FS.FolderPath location)
        {
            var names = src.ReferenceNames();
            foreach(var name in names)
            {
                var component = from(context, name.DllPath(location));
                yield return component;
                foreach(var r in load(context, component, location))
                    yield return r;
            }
        }

        public readonly FS.FolderPath Home;

        public Assembly Component {get;}

        public ReadOnlySeq<Assembly> Dependencies {get;}

        public PartLoadContext(FS.FilePath src)
            : base(true)
        {
            Home = src.FolderPath;
            Component = LoadFromAssemblyPath(src.Name);
            Dependencies = deps(this, Component);
        }


        public void Dispose()
        {
            Unload();
        }
    }
}