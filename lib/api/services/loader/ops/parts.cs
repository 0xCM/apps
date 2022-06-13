//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiRuntimeLoader
    {
        // public static FS.FilePath path(Assembly src)
        //     => FS.path(src.Location);

        // public static FS.FolderPath dir(Assembly src)
        //     => path(src).FolderPath;

        // public static IApiParts parts(Assembly control, string[] args, bool libonly)
        // {
        //     if(args.Length == 0)
        //         return new ApiParts(control, ApiRuntime.assemblies(dir(control), true, libonly).Select(x => x.Id()), libonly);
        //     var parts = ApiRuntimeLoader.parts(args, libonly);
        //     if(parts.Length != 0)
        //         return new ApiParts(control, array<PartId>(control.Id()), libonly);
        //     else
        //         return new ApiParts(control, parts, libonly);
        // }


        // [Op]
        // public static Index<PartId> parts(ReadOnlySpan<string> src, bool libonly)
        // {
        //     var count = src.Length;
        //     if(count == 0)
        //         return sys.empty<PartId>();

        //     var symbols = Symbols.index<PartId>();
        //     var dst = span<PartId>(count);
        //     var counter = 0u;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var name = ref skip(src,i);
        //         if(symbols.Lookup(name, out var sym))
        //         {
        //             if(libonly && sym.Kind >= FirstShell)
        //                 continue;
        //             seek(dst, counter++) = sym.Kind;
        //         }
        //     }
        //     return slice(dst, 0, counter).ToArray();
        // }
    }
}