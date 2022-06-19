//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiRuntimeLoader
    {

        // public static Assembly[] assemblies(bool justParts, bool libonly)
        //     => assemblies(location(), justParts, libonly);

        // public static Index<Assembly> assemblies(FS.FolderPath dir, PartId[] parts)
        // {
        //     var dst = list<Assembly>();
        //     var candidates = dir.TopFiles;
        //     foreach(var path in candidates)
        //     {
        //         if((path.Is(FS.Dll) || path.Is(FS.Exe)) && FS.managed(path))
        //         {
        //             foreach(var id in parts)
        //             {
        //                 var match = dir + FS.component(id, path.Ext);
        //                 if(match.Equals(path))
        //                     dst.Add(Assembly.LoadFrom(match.Name));
        //             }
        //         }
        //     }

        //     return dst.ToArray();
        // }


        // [Op]
        // public static Assembly[] assemblies(FS.FilePath[] src)
        //     => src.Where(x => FS.managed(x)).Map(assembly).Where(x => x.IsSome()).Select(x => x.Value);

        // public static Assembly[] assemblies(FS.FolderPath dir, bool justParts, bool libonly)
        // {
        //     var dst = list<Assembly>();
        //     var candidates = managed(dir, libonly);
        //     foreach(var path in candidates)
        //     {
        //         var component = Assembly.LoadFrom(path.Name);
        //         if(justParts)
        //         {
        //             if(component.Id() != 0)
        //                 dst.Add(component);
        //         }
        //         else
        //             dst.Add(component);
        //     }

        //     return dst.ToArray();
        // }
    }
}