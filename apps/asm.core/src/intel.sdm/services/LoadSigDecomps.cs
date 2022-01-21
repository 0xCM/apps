//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<SigOpCode> LoadSigDecomps()
        {
            return Data(nameof(LoadSigDecomps),Load);

            Index<SigOpCode> Load()
            {
                var dst = sys.empty<SigOpCode>();
                var src = ProjectDb.TablePath<SigOpCode>("sdm", "decomposed");
                var lines = src.ReadNumberedLines();
                var count = lines.Count - 1;
                dst = alloc<SigOpCode>(count);
                SdmOps.rows(slice(lines.View, 1), dst);
                return dst;
            }
        }
    }
}