//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public ReadOnlySeq<AssemblyRefInfo> ReadAssemblyRefs(Assembly src)
        {
            var path = FS.path(src.Location);
            if(ClrModules.valid(path))
            {
                using var reader = PeReader.create(path);
                return reader.ReadAssemblyRefs();
            }
            else
                return ReadOnlySeq<AssemblyRefInfo>.Empty;
        }

        public ReadOnlySeq<AssemblyRefInfo> ReadAssemblyRefs()
        {
            var components = ApiMd.Components;
            var count = components.Length;
            var dst = list<AssemblyRefInfo>();
            for(var i=0; i<count; i++)
            {
                ref readonly var assembly = ref skip(components,i);
                var path = FS.path(assembly.Location);
                if(ClrModules.valid(path))
                {
                    using var reader = PeReader.create(path);
                    var refs = reader.ReadAssemblyRefs();
                    iter(refs,r => dst.Add(r));
                }
            }
            dst.Sort();
            return dst.ToArray();
        }
    }
}