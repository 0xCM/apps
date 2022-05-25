//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiExtractor
    {
        ApiHostDataset CreateDataset(ApiHostCode code, Index<AsmRoutine> asm)
        {
            var dst = new ApiHostDataset();
            dst.HostResolution = code.Resolved;
            dst.HostExtracts = code.Raw;
            dst.HostBlocks = code.Parsed;
            dst.Routines = asm;
            return dst;
        }
    }
}