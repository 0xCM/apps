//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using PCK = ProcessContextFlag;

    [ApiHost,Free]
    public partial class ImageMemory
    {
        [MethodImpl(Inline)]
        public static bit enabled(PCK src, PCK flag)
            => (src & flag) != 0;

        [MethodImpl(Inline)]
        public static ProcessContextFlags flags(PCK src)
        {
            var options = new ProcessContextFlags();
            options.EmitSummary = enabled(src,PCK.Summary);
            options.EmitDetail= enabled(src,PCK.Detail);
            options.EmitDump= enabled(src,PCK.Dump);
            options.EmitHashes = enabled(src,PCK.Hashes);
            return options;
        }

        [MethodImpl(Inline), Op]
        public static ref ProcessSegment segment(in ProcessMemoryRegion src, ref ProcessSegment dst)
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