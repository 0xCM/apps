//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Operand<T> : Operand, IOperand<T>
        where T : unmanaged, IType<T>
    {
        public Operand(Identifier name, T type, ParamDirection direction, Facets facets)
            : base(name, type, direction, facets)
        {
            Type = type;
        }

        public new T Type {get;}
    }
}