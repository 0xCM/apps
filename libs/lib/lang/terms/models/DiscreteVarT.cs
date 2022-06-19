//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiscreteVar<T> : IVar<T>
        where T : IExpr
    {
        Index<VarSymbol> _Names;

        public VarSymbol Name {get; private set;}

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