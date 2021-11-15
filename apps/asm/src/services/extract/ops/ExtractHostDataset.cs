//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiExtractor
    {
        ApiHostDataset ExtractHostDatast(in ResolvedHost src)
        {
            var dst = new ApiHostDataset();
            dst.HostResolution = src;
            var host = src.Host;
            var extracts = ExtractHost(src).Sort();
            dst.HostExtracts = extracts;
            EmitRawHex(host, extracts.View);
            var parsed = ParseExtracts(extracts.View);
            dst.HostBlocks = parsed;
            EmitParsedHex(host, parsed.View);
            var decoded = DecodeMembers(parsed.View);
            dst.Routines = decoded;
            EmitAsmSource(host, decoded);
            return dst;
        }
    }
}