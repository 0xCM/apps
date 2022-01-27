//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class ValueProduction : ValueProduction<@string>, INullity, IProduction
    {
        [MethodImpl(Inline)]
        public ValueProduction(string src, string dst)
            : base(src,dst)
        {

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

        IExpr IArrow<IExpr, IExpr>.Source
            => Source;

        IExpr IArrow<IExpr, IExpr>.Target
            => Target;

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
        public static implicit operator ValueProduction((string src, string dst) x)
            => new ValueProduction(x.src,x.dst);
    }
}