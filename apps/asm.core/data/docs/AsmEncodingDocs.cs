//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    public sealed class AsmEncodingDocs : ConstLookup<FS.FilePath,AsmEncodingDoc>
    {
        public AsmEncodingDocs(Dictionary<FS.FilePath, AsmEncodingDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmEncodingDocs(Dictionary<FS.FilePath, AsmEncodingDoc> src)
            => new AsmEncodingDocs(src);
    }
}