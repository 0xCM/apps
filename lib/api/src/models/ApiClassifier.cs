//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiClassifier
    {
        public Name Type {get;}

        public Index<SymLiteralRow> Literals {get;}

        [MethodImpl(Inline)]
        public ApiClassifier(Name type, Index<SymLiteralRow> literals)
        {
            Type = type;
            Literals = literals;
        }
    }
}