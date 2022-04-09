//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDocs
    {
        public class InstDoc
        {
            public readonly Index<InstDocPart> Parts;

            public readonly RuleTables Tables;

            public InstDoc(RuleTables tables, InstDocPart[] src)
            {
                Tables = tables;
                Parts = src;
            }

            public ref InstDocPart this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public ref InstDocPart this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public string Format()
                => new InstDocFormatter(Tables,this).Format();

            public override string ToString()
                => Format();
        }
    }
}