//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiClassifier
    {
        public readonly Name Type;

        public readonly Index<SymLiteralRow> Literals;

        [MethodImpl(Inline)]
        public ApiClassifier(Name type, Index<SymLiteralRow> literals)
        {
            Type = type;
            Literals = literals;
        }
    }
}