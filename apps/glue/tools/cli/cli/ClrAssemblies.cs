//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.IO;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct ClrAssemblies
    {
        [Op]
        public static ClrComponentInfo describe(Assembly src)
        {
            var dst = new ClrComponentInfo();
            var adapted = Clr.adapt(src);
            dst.ImgPath = location(src);
            pdbpath(adapted, out dst.PdbPath);
            xmlpath(adapted, out dst.XmlPath);
            dst.MetadatSize = (ByteSize)adapted.RawMetadata.Length;
            return dst;
        }

        [Op]
        public static uint describe(ReadOnlySpan<Assembly> src, Span<ClrComponentInfo> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = describe(skip(src,i));
            return count;
        }

        /// <summary>
        /// Loads an assembly + pdb
        /// </summary>
        /// <param name="image">The assembly path</param>
        /// <param name="pdb">The pdb path</param>
        [Op]
        public static Assembly load(FS.FilePath image, FS.FilePath pdb)
            => Assembly.Load(image.ReadBytes(), pdb.ReadBytes());

        [MethodImpl(Inline), Op]
        public static FS.FilePath location(ClrAssemblyAdapter src)
            => FS.path(src.Definition.Location);

        [Op]
        public static ref readonly FS.FilePath xmlpath(ClrAssemblyAdapter src, out FS.FilePath dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Xml.Name));
            dst = candidate.Exists ? candidate : FS.FilePath.Empty;
            return ref dst;
        }

        [Op]
        public static ref readonly FS.FilePath pdbpath(ClrAssemblyAdapter src, out FS.FilePath dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Pdb.Name));
            dst = candidate.Exists ? candidate : FS.FilePath.Empty;
            return ref dst;
        }
    }
}