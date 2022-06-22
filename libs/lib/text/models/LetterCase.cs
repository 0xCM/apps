//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LetterCase
    {
        public bool IsUpper {get;}

        public bool IsLower {get;}

        public LetterCaseKind Kind {get;}

        [MethodImpl(Inline)]
        internal LetterCase(bool upper, bool lower, LetterCaseKind kind)
        {
            IsUpper = upper;
            IsLower = lower;
            Kind = kind;
        }
    }
}