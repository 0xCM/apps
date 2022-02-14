//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class McAsmSyntaxDoc : TableDoc<AsmSyntaxRow>
    {
        public McAsmSyntaxDoc(FS.FilePath src, AsmSyntaxRow[] rows)
            : base(src,rows)
        {

        }
    }
}