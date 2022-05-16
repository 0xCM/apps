//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiRuntimeLoader
    {
        public static IApiParts parts(bool libonly = true)
            => parts(controller(), Environment.GetCommandLineArgs(), libonly);

        public static IApiParts parts(Assembly control, string[] args, bool libonly)
        {
            if(args.Length == 0)
                return new ApiParts(control, assemblies(dir(control), true, libonly).Select(x => x.Id()), libonly);

            var parts = ParseParts(args, libonly);
            if(parts.Length != 0)
                return new ApiParts(control, array<PartId>(control.Id()), libonly);
            else
                return new ApiParts(control, parts.ToArray(), libonly);
        }

        public static IApiParts parts(Assembly control, bool libonly)
            => new ApiParts(control, array(control.Id()), libonly);

        /// <summary>
        /// Creates a <see cref='ApiParts'/> predicated an optionally-specified <see cref='PartId'/> sequence
        /// where the entry assembly is assumed to be the locus of control
        /// </summary>
        /// <param name="control">The controlling assembly</param>
        /// <param name="names">The desired parts to include, or empty to include all known parts</param>
        public static IApiParts parts(PartId[] names, bool libonly)
            => parts(controller(), names, libonly);

        /// <summary>
        /// Creates a <see cref='ApiParts'/> predicated an optionally-specified <see cref='PartId'/> sequence
        /// </summary>
        /// <param name="control">The controlling assembly</param>
        /// <param name="names">The desired parts to include, or empty to include all known parts</param>
        [Op]
        public static IApiParts parts(Assembly control, PartId[] names, bool libonly)
        {
            if(names.Length != 0)
               return new ApiParts(control, names, libonly);
            else
                return new ApiParts(control, FS.path(control.Location).FolderPath, libonly);
        }

        [Op]
        public static ReadOnlySpan<PartId> ParseParts(ReadOnlySpan<string> src, bool libonly)
        {
            var count = src.Length;
            if(count == 0)
                return sys.empty<PartId>();

            var symbols = Symbols.index<PartId>();
            var dst = span<PartId>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(src,i);
                if(symbols.Lookup(name, out var sym))
                {
                    if(libonly && sym.Kind >= FirstShell)
                        continue;
                    seek(dst, counter++) = sym.Kind;
                }
            }
            return slice(dst, 0, counter);
        }

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

                dst.Add((id, dir + FS.file(name, FS.Exe)));
            }
            return dst.ViewDeposited();
        }

        static IPart[] LoadParts(FS.FolderPath dir, ReadOnlySpan<PartId> parts, bool libonly)
        {
            var count = parts.Length;
            var dst = list<IPart>();
            var set = hashset<PartId>();
            iter(parts, p => set.Add(p));
            var candidates = PartPaths(dir);
            foreach(var (id,path) in candidates)
            {
                if(libonly && id >= FirstShell)
                    continue;

                if(set.Contains(id))
                    part(path).OnSome(part => dst.Add(part));
            }
            return dst.ToArray();
        }

        static IPart[] FindParts(PartLoadContext context)
            => from component in context.Assemblies.Array().Where(x => x.Id() != 0)
                let part = TryLoadPart(component)
                where part.IsSome()
                select part.Value;
    }
}