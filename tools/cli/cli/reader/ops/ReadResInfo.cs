//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;
    using System.Linq;

    using static Root;
    using static core;

    partial class CliReader
    {
        [Op]
        public ReadOnlySpan<ManifestResourceHandle> ResourceHandles()
            => MD.ManifestResources.ToReadOnlySpan();

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<ManifestResourceInfo> ReadResInfo()
        {
            var handles = ResourceHandles();
            return ReadResInfo(handles, alloc<ManifestResourceInfo>(handles.Length));
        }

        [MethodImpl(Inline), Op]
        public static ManifestResourceHandle ResourceHandle(uint row)
            => MetadataTokens.ManifestResourceHandle((int)row);


        [MethodImpl(Inline), Op]
        public Span<ManifestResourceInfo> ReadResInfo(ReadOnlySpan<ManifestResourceHandle> src, Span<ManifestResourceInfo> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadResInfo(ReadResource(skip(src,i), out var _), ref seek(dst,i));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public ref ManifestResource ReadResource(ManifestResourceHandle src, out ManifestResource dst)
        {
            dst = Read(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public ref ManifestResourceInfo ReadResInfo(in ManifestResource src, ref ManifestResourceInfo dst)
        {
            dst.Name = Read(src.Name);
            dst.Offset = (ulong)src.Offset;
            dst.Attributes = src.Attributes;
            return ref dst;
        }
    }
}