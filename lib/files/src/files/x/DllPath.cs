//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using System.Runtime.Loader;
    using System.Reflection;
    using System.Collections.Generic;

    partial class XFs
    {
        [Op]
        public static Assembly LoadFrom(this AssemblyLoadContext context, FS.FilePath src)
            => context.LoadFromAssemblyPath(src.Name);

        [Op]
        public static FS.FilePath DllPath(this AssemblyName src, FS.FolderPath dir)
            => dir + FS.file(src.SimpleName(), FS.Dll);

        public static IEnumerable<Assembly> LoadPartDependencies(this AssemblyLoadContext context, Assembly src, FS.FolderPath location)
        {
            var names = src.PartReferenceNames();
            foreach(var name in names)
            {
                var component = context.LoadFrom(name.DllPath(location));
                yield return component;
                foreach(var r in LoadPartDependencies(context, component, location))
                    yield return r;
            }
        }
    }
}