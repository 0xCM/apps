//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NamedTerm : INamedTerm
    {
        public Name Name {get;}

        public Index<IExpr> Terms {get;}

        public NamedTerm(string name, IExpr[] terms)
        {
            Name = name;
            Terms = terms;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public string Format()
        {
            if(IsEmpty)
                return EmptyString;

            if(Terms.Count == 0)
                return Name;

            return string.Format("<{0}> := {1}", Name, Terms.Delimit(Chars.Pipe));
        }

        public override string ToString()
            => Format();
    }
}