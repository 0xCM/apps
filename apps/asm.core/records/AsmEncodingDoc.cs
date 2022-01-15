//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class AsmEncodingDoc : TableDoc<AsmStatementEncoding>
    {
        public AsmEncodingDoc(FS.FilePath src, AsmStatementEncoding[] rows)
            : base(src,rows)
        {
        }

        public static AsmEncodingDoc Empty
        {
            get => new AsmEncodingDoc(FS.FilePath.Empty, sys.empty<AsmStatementEncoding>());
        }
    }
}