//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiscreteVar : IVar
    {
        Index<Name> _Names;

        public Name Name {get; private set;}


        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public DiscreteVar(Name[] domain, Name name)
        {
            _Names = domain;
            Name = name;
        }

        public ReadOnlySpan<Name> Names
        {
            [MethodImpl(Inline)]
            get => _Names;
        }

        public DiscreteVar Select(Name name)
        {
            Name = name;
            return this;
        }
    }
}