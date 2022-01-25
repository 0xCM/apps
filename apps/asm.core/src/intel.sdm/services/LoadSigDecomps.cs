//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<SdmSigOpCode> LoadSigDecomps()
        {
            return Data(nameof(LoadSigDecomps),Load);

            Index<SdmSigOpCode> Load()
            {
                var dst = sys.empty<SdmSigOpCode>();
                var src = ProjectDb.TablePath<SdmSigOpCode>("sdm", "decomposed");
                var lines = src.ReadNumberedLines();
                var count = lines.Count - 1;
                dst = alloc<SdmSigOpCode>(count);
                SdmOps.rows(slice(lines.View, 1), dst);
                return dst;
            }
        }
    }
}