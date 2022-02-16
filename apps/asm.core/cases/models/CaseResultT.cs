//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct CaseResult<T>
    {
        public readonly T Case;

        public readonly Outcome Outcome;

        [MethodImpl(Inline)]
        public CaseResult(T @case, Outcome outcome)
        {
            Case = @case;
            Outcome = outcome;
        }

        [MethodImpl(Inline)]
        public static implicit operator CaseResult<T>((T @case, Outcome outcome) src)
            => new CaseResult<T>(src.@case,src.outcome);
    }
}