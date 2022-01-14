//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Asm;

    using static Root;

    public class AsmEncodingDoc : TableDoc<AsmStatementEncoding>
    {
        public AsmEncodingDoc(FS.FilePath src, AsmStatementEncoding[] rows)
            : base(src,rows)
        {
            // Location = src;
            // Data = rows;
        }

        public static AsmEncodingDoc Empty
        {
            get => new AsmEncodingDoc(FS.FilePath.Empty, sys.empty<AsmStatementEncoding>());
        }
    }
}