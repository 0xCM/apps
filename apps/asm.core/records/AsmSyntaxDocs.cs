//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    public sealed class AsmSyntaxDocs : ConstLookup<FS.FilePath,AsmSyntaxDoc>
    {
        public AsmSyntaxDocs(Dictionary<FS.FilePath, AsmSyntaxDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmSyntaxDocs(Dictionary<FS.FilePath, AsmSyntaxDoc> src)
            => new AsmSyntaxDocs(src);
    }
}