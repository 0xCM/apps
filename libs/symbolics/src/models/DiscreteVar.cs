//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiscreteVar : IVar
    {
        Index<NameOld> _Names;

        public NameOld Name {get; private set;}


        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public DiscreteVar(NameOld[] domain, NameOld name)
        {
            _Names = domain;
            Name = name;
        }

        public ReadOnlySpan<NameOld> Names
        {
            [MethodImpl(Inline)]
            get => _Names;
        }

        public DiscreteVar Select(NameOld name)
        {
            Name = name;
            return this;
        }
    }
}