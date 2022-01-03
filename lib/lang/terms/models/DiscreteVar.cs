//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = Terms;

    public class DiscreteVar : IVar
    {
        Index<VarSymbol> _Names;

        public VarSymbol Name {get; private set;}

        public DiscreteVar(VarSymbol[] domain, VarSymbol name)
        {
            _Names = domain;
            Name = name;
        }

        public ReadOnlySpan<VarSymbol> Names
        {
            [MethodImpl(Inline)]
            get => _Names;
        }

        public DiscreteVar Select(VarSymbol name)
        {
            Name = name;
            return this;
        }
    }
}