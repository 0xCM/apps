//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmEncodingDocs : ConstLookup<FileRef,AsmEncodingDoc>
    {
        public AsmEncodingDocs(Dictionary<FileRef, AsmEncodingDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmEncodingDocs(Dictionary<FileRef, AsmEncodingDoc> src)
            => new AsmEncodingDocs(src);
    }
}