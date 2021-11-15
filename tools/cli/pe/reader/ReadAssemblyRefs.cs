//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static core;

    partial class PeReader
    {
        [Op]
        public ReadOnlySpan<AssemblyRefInfo> ReadAssemblyRefs()
        {
            var src = CliReader().AssemblyRefHandles();
            var dst = alloc<AssemblyRefInfo>(src.Length);
            ReadAssemblyRefs(src, dst);
            return dst;
        }

        [Op]
        public void ReadAssemblyRefs(ReadOnlySpan<AssemblyReferenceHandle> src, Span<AssemblyRefInfo> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                var ar = MD.GetAssemblyReference(skip(src,i));
                ReadAssemblyRef(ar, ref seek(dst,i));
            }
        }

        [Op]
        public ref AssemblyRefInfo ReadAssemblyRef(AssemblyReference src, ref AssemblyRefInfo dst)
        {
            dst.Source = AssemblyName();
            dst.Target = src.GetAssemblyName();
            dst.Token = CliReader().Read(src.PublicKeyOrToken);
            return ref dst;
        }
    }
}