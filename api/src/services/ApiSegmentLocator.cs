//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class ApiSegmentLocator : AppService<ApiSegmentLocator>
    {
        public ReadOnlySpan<ProcessSegment> LocateSegments(AddressBank src, ReadOnlySpan<ApiMemberInfo> methods, FS.FolderPath dir)
        {
            var count = methods.Length;
            var flow = Wf.Running(Msg.LocatingSegments.Format(count));
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
                    Wf.Error(Msg.SegSelectorNotFound.Format(selector));
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
                    Wf.Error(string.Format("Could not locate the segment containing the entry point {0} for {1}", method.EntryPoint, method.Uri));
                    break;
                }
            }

            var located = TableEmit(@readonly(buffer), MethodSegment.RenderWidths, Db.Table<MethodSegment>(dir));
            Wf.Ran(flow, Msg.LocatedSegments.Format(located, count));
            return locations.Array().Sort();
        }
    }
}