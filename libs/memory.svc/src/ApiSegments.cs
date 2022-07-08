//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ImageSegments : WfSvc<ImageSegments>
    {
        static MsgPattern<Address16> SegSelectorNotFound => "Selector {0} not found";

        static MsgPattern<Count> LocatingSegments => "Locating segments for {0} methods";

        static MsgPattern<Count,Count> LocatedSegments => "Computed {0} segment entries for {0} methods";

        IDumpArchive Dumps => DumpArchive.Service;

        public ProcAddresses EmitSegments(Timestamp ts)
            => EmitSegments(ts, ImageMemory.regions());

        public ProcAddresses EmitSegments(Timestamp ts, ReadOnlySeq<ProcessMemoryRegion> src)
        {
            var addresses = ImageRegions.addresses(src);
            TableEmit(addresses.Segments, Dumps.Table<ProcessSegment>("segments", ts));
            return addresses;
        }

        public ReadOnlySpan<ProcessSegment> LocateSegments(ProcAddresses src, ReadOnlySpan<ApiMemberInfo> methods, FS.FolderPath dir)
        {
            var count = methods.Length;
            var flow = Running(LocatingSegments.Format(count));
            var buffer = alloc<MethodSegment>(count);
            var locations = hashset<ProcessSegment>();
            var segments  = src.Segments;
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var method = ref skip(methods,i);
                ref readonly var address = ref method.EntryPoint;
                var selector = address.Quadrant(n2);
                var index = src.SelectorIndex(selector);
                if(index == NotFound)
                {
                    Error(SegSelectorNotFound.Format(selector));
                    break;
                }

                ref var entry = ref seek(dst,i);
                entry.MethodIndex = i;
                entry.EntryPoint = address;
                entry.SegSelector = selector;
                entry.Uri = method.Uri;
                var bases = src.Bases((ushort)index);
                var match = address.Lo;
                var matched = false;
                for(var j=0u; j<bases.Length; j++)
                {
                    ref readonly var @base = ref skip(bases,j);
                    var min = @base.Left;
                    var max = min + @base.Right;
                    if(match.Between(@base.Left, @base.Left + @base.Right))
                    {
                        ref readonly var found = ref skip(segments,j);
                        entry.SegIndex = j;
                        entry.SegStart =  ((ulong)selector << 32) | (MemoryAddress)found.Base;
                        entry.SegSize = found.Size;
                        entry.SegEnd = ((ulong)selector << 32) | ((MemoryAddress)found.Base + found.Size);
                        locations.Add(found);
                        matched = true;
                        break;
                    }
                }
                if(!matched)
                {
                    Error(string.Format("Could not locate the segment containing the entry point {0} for {1}", method.EntryPoint, method.Uri));
                    break;
                }
            }

            TableEmit(@readonly(buffer), Db.Table<MethodSegment>(dir));
            Ran(flow, LocatedSegments.Format(buffer.Length, count));
            return locations.Array().Sort();
        }
    }
}