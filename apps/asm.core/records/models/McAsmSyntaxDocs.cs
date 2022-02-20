//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class McAsmSyntaxDocs : ConstLookup<FS.FilePath,McAsmSyntaxDoc>
    {
        public McAsmSyntaxDocs(Dictionary<FS.FilePath, McAsmSyntaxDoc> src)
            : base(src)
        {


        }

        public static implicit operator McAsmSyntaxDocs(Dictionary<FS.FilePath, McAsmSyntaxDoc> src)
            => new McAsmSyntaxDocs(src);
    }
}