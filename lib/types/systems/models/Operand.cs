//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;


    public class Operand : IOperand
    {
        public Identifier Name {get;}

        public IType Type {get;}

        public ParamDirection Direction {get;}

        public Facets Facets {get;}

        public Operand(Identifier name, IType type, ParamDirection direction, Facets facets)
        {
            Name = name;
            Type = type;
            Direction = direction;
            Facets = facets;
        }

        public bool IsEmpty
        {
            get => Type.IsEmpty;
        }

        public bool IsNonEmpty
        {
            get => Type.IsNonEmpty;
        }

        public string Format()
            => OperandFormatter.Service.Format(this);

        public override string ToString()
            => Format();

        public static Operand Empty => new Operand(EmptyString, Null.Empty, 0, Facets.Empty);
    }
}