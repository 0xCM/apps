//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;
    using static Spans;

    partial struct ApiLoader
    {
        public static IApiCatalog catalog()
            => catalog(location());

        public static IApiCatalog catalog(FS.FolderPath src)
        {
            var candidates = ApiRuntime.assemblies(src, true).Where(x => x.Id() != 0);
            var count = candidates.Length;
            var parts = list<IPart>();
            for(var i=0; i<count; i++)
            {
                if(TryLoadPart(skip(candidates,i), out var part))
                    parts.Add(part);
            }

            return catalog(parts.Array());
        }

        public static IApiCatalog catalog(FS.FolderPath src, PartId[] parts)
            => catalog(ApiLoader.parts(src, parts));

        public static IPart[] parts(FS.FolderPath src, ReadOnlySpan<PartId> parts)
        {
            var count = parts.Length;
            var dst = list<IPart>();
            var set = hashset<PartId>();
            iter(parts, p => set.Add(p));
            var candidates = PartPaths(src);
            foreach(var (id,path) in candidates)
            {
                if(set.Contains(id))
                    part(path).OnSome(part => dst.Add(part));
            }
            return dst.ToArray();
        }

        // public static IApiCatalog catalog(FS.Files paths)
        //     => catalog(paths.Storage.Select(part).Where(x => x.IsSome()).Select(x => x.Value).OrderBy(x => x.Id));

        public static ApiPartCatalog catalog(Assembly src)
            => new ApiPartCatalog(src.Id(), src, complete(src), hosts(src), SvcHostTypes(src));

        public static IApiCatalog catalog(IPart[] src)
        {
            var catalogs = src.Select(x => catalog(x.Owner)).Where(c => c.IsIdentified);
            var dst = new ApiRuntimeCatalog(src,
                src.Select(p => p.Owner),
                catalogs,
                catalogs.SelectMany(c => c.ApiHosts.Storage).Where(h => nonempty(h.HostUri.HostName)),
                src.Select(p => p.Id),
                catalogs.SelectMany(x => x.Methods)
                );
            return dst;
        }

        static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        static ReadOnlySpan<Paired<PartId,FS.FilePath>> PartPaths(FS.FolderPath dir)
        {
            var dst = list<Paired<PartId,FS.FilePath>>();
            var symbols = Symbols.index<PartId>().View;
            var count = symbols.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                var id = symbol.Kind;
                var name = "z0." + symbol.Expr.Format();
                dst.Add((id, dir + FS.file(name, FS.Dll)));
                //dst.Add((id, dir + FS.file(name, FS.Exe)));
            }
            return dst.ViewDeposited();
        }
    }
}