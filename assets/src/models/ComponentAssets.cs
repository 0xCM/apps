//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    public readonly struct ComponentAssets : IIndex<Asset>
    {
        [Op]
        public static ComponentAssets from(Assembly src)
            => new ComponentAssets(src, collect(src));

        [Op]
        static unsafe Index<Asset> collect(Assembly src)
        {
            var resnames = @readonly(src.GetManifestResourceNames());
            var count = resnames.Length;
            if(count == 0)
                return array<Asset>();

            var buffer = alloc<Asset>(count);
            var target = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref skip(resnames, i);
                var stream = (UnmanagedMemoryStream)src.GetManifestResourceStream(name);
                seek(target,i) = Resources.descriptor(name, stream.PositionPointer, (uint)stream.Length);
            }
            return buffer;
        }

        readonly Index<Asset> Data;

        public Assembly Source {get;}

        [MethodImpl(Inline)]
        public ComponentAssets(Assembly src, Index<Asset> descriptors)
        {
            Data = descriptors;
            Source = src;
        }

        public uint ResourceCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Asset[] Storage
        {
            get => Data.Storage;
        }

        public ReadOnlySpan<Asset> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly Asset this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public ref readonly Asset Descriptor(uint index)
            => ref Data[index];

        [MethodImpl(Inline)]
        public ComponentAssets Filter(string match)
            => new ComponentAssets(Source, Data.Storage.Where(x => x.NameLike(match)));

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Content(uint index)
        {
            ref readonly var src = ref Descriptor(index);
            return core.view(src.Address, src.Size);
        }
    }
}