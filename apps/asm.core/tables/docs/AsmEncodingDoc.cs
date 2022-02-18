//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmEncodingDoc : TableDoc<AsmEncodingRow>
    {
        public AsmEncodingDoc(FS.FilePath src, AsmEncodingRow[] rows)
            : base(src,rows)
        {
        }

        public static implicit operator AsmEncodingDoc((FS.FilePath src, AsmEncodingRow[] rows) x)
            => new AsmEncodingDoc(x.src,x.rows);

        public static AsmEncodingDoc Empty
            => new AsmEncodingDoc(FS.FilePath.Empty, sys.empty<AsmEncodingRow>());
    }
}