//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class NamedTerm : INamedTerm
    {
        public Name Name {get;}

        public Index<ITerm> Terms {get;}

        public NamedTerm(string name, ITerm[] terms)
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