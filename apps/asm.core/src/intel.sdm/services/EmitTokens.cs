//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    using static core;

    partial class IntelSdm
    {
        public Index<AsmToken> EmitTokens()
        {
            var sigs = AsmSigs.tokens().View;
            var sigcount = sigs.Length;
            var opcodes = AsmOpCodes.tokens().View;
            var occount = opcodes.Length;
            var count = sigcount + occount;
            var buffer = alloc<AsmToken>(count);
            var j=0u;
            for(var i=0u; i<occount; i++,j++)
            {
                seek(buffer,j) = skip(opcodes,i);
                seek(buffer,j).Id = j;
            }

            for(var i=0u; i<sigcount; i++,j++)
            {
                seek(buffer,j) = skip(sigs,i);
                seek(buffer,j).Id = j;
            }

            TableEmit(@readonly(buffer), AsmToken.RenderWidths, ProjectDb.Subdir("sdm") + Tables.filename<AsmToken>());
            return buffer;
        }
    }
}