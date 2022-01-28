//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class Production : Production<RuleValue<@string>, RuleValue<@string>>, INullity, IProduction
    {
        [MethodImpl(Inline)]
        public Production(@string src, @string dst)
            : base(src, dst)
        {

        }

        new @string Source
        {
            get => base.Source;
        }

        new @string Target
        {
            get => base.Target;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty && Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty || Target.IsNonEmpty;
        }

        public override string Format()
        {
            if(Source.IsNonEmpty && Target.IsNonEmpty)
                return string.Format("{0} -> {1}", Source, Target);
            else if(Source.IsNonEmpty)
                return Source.Format();
            else if(Target.IsNonEmpty)
                return Target.Format();
            else
                return EmptyString;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Production((string src, string dst) x)
            => new Production(x.src,x.dst);
    }
}