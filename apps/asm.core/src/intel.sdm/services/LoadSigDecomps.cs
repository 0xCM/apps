//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmSigOpCode> LoadSigDecomps()
        {
            return Data(nameof(LoadSigDecomps),Load);

            Index<AsmSigOpCode> Load()
            {
                var dst = sys.empty<AsmSigOpCode>();
                var src = ProjectDb.TablePath<AsmSigOpCode>("sdm", "decomposed");
                var lines = src.ReadNumberedLines();
                var count = lines.Count - 1;
                dst = alloc<AsmSigOpCode>(count);
                SdmOps.rows(slice(lines.View, 1), dst);
                return dst;
            }
        }
    }
}