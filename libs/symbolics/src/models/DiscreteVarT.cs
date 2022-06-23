//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiscreteVar<T>
        where T : IExpr
    {
        Index<VarSymbol> _Names;

        public VarSymbol Name {get; private set;}

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public T Value {get; private set;}

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

        public DiscreteVar<T> Set(VarSymbol name, T value)
        {
            Name = name;
            Value = value;
            return this;
        }
    }
}