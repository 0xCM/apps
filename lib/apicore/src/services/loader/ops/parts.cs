//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    partial struct ApiRuntimeLoader
    {
        public static IApiParts parts()
            => parts(controller(), Environment.GetCommandLineArgs());

        public static IApiParts parts(Assembly control)
            => new ApiParts(control, array(control.Id()));

        /// <summary>
        /// Creates a <see cref='ApiParts'/> predicated an optionally-specified <see cref='PartId'/> sequence
        /// where the entry assembly is assumed to be the locus of control
        /// </summary>
        /// <param name="control">The controlling assembly</param>
        /// <param name="identifiers">The desired parts to include, or empty to include all known parts</param>
        public static IApiParts parts(PartId[] identifiers)
            => parts(controller(), identifiers);

        public static IApiParts parts(Assembly control, string[] args)
        {
            if(args.Length != 0)
            {
                var identifiers = ApiParsers.parts(args);
                if(identifiers.Length != 0)
                    return new ApiParts(control, identifiers.ToArray());
                else
                    return new ApiParts(control, array<PartId>(control.Id()));
            }
            else
            {
                return new ApiParts(control, assemblies(dir(control), true).Select(x => x.Id()));
            }
                //return new ApiParts(control, dir(control));
        }

        /// <summary>
        /// Creates a <see cref='ApiParts'/> predicated an optionally-specified <see cref='PartId'/> sequence
        /// </summary>
        /// <param name="control">The controlling assembly</param>
        /// <param name="identifiers">The desired parts to include, or empty to include all known parts</param>
        [Op]
        public static IApiParts parts(Assembly control, PartId[] identifiers)
        {
            if(identifiers.Length != 0)
               return new ApiParts(control, identifiers);
            else
                return new ApiParts(control, FS.path(control.Location).FolderPath);
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
                var dllpath = dir + FS.file(name, FS.Dll);
                if(dllpath.Exists)
                    dst.Add((id,dllpath));

                var exepath = dir + FS.file(name, FS.Exe);
                if(exepath.Exists)
                    dst.Add((id,exepath));
            }
            return dst.ViewDeposited();
        }

        static IPart[] LoadParts(FS.FolderPath dir, ReadOnlySpan<PartId> parts)
        {
            var count = parts.Length;
            var dst = list<IPart>();
            var set = hashset<PartId>();
            iter(parts, p => set.Add(p));
            var candidates = PartPaths(dir);
            foreach(var (id,path) in candidates)
            {
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