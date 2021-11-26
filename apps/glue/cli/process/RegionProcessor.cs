//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public sealed class RegionProcessor : SpanProcessor<RegionProcessor,ProcessMemoryRegion>
    {
        List<Address16> Selectors;

        List<List<Paired<Address32,uint>>> Bases;

        Index<ProcessSegment> _Segments;

        AddressBank _Bank;

        string HostProcessName;

        public RegionProcessor()
        {
            Selectors = new();
            Bases = new();
            _Segments = new();
            HostProcessName = process().ProcessName;
        }

        protected override void Complete()
        {
            _Bank = new AddressBank(_Segments, Selectors.ToArray(), Bases.ToArray());
        }

        public ref readonly AddressBank Bank
        {
            [MethodImpl(Inline)]
            get => ref _Bank;
        }

        ushort Index(Address16 selector)
        {
            var index = Selectors.IndexOf(selector);
            if(index == NotFound)
            {
                Selectors.Add(selector);
                index = Selectors.Count - 1;
                Bases.Add(list<Paired<Address32,uint>>());
            }
            return (ushort)index;
        }

        public Index<ProcessSegment> Segments
            => _Segments;

        protected override uint Process(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var count = (uint)src.Length;
            _Segments = alloc<ProcessSegment>(count);
            for(var i=0u; i<count; i++)
                Include(i, skip(src,i));
            return count;
        }

        void Include(uint index, in ProcessMemoryRegion src)
        {
            var id = src.Identity.Format();
            if(text.empty(id))
                id = src.FullIdentity;
            if(id.StartsWith(HostProcessName))
                id = string.Format("host::{0}", id);

            if(src.Type != 0 && src.Protection != 0)
            {
                var selector = src.StartAddress.Quadrant(n2);
                var @base = src.StartAddress.Lo;
                var sidx = (ushort)Index(selector);
                Bases[sidx].Add(paired(@base, (uint)src.Size));
                load(src, ref _Segments[index]);
            }
        }

        [MethodImpl(Inline), Op]
        public static ref ProcessSegment load(in ProcessMemoryRegion src, ref ProcessSegment dst)
        {
            dst.Index = src.Index;
            dst.Selector = src.StartAddress.Quadrant(n2);
            dst.Base = src.StartAddress.Lo;
            dst.Size = src.Size;
            dst.PageCount = src.Size/PageSize;
            dst.Range = (src.StartAddress, src.EndAddress);
            dst.Type = src.Type;
            dst.Protection = src.Protection;
            dst.Label = src.Identity.Format();
            return ref dst;
        }
    }
}