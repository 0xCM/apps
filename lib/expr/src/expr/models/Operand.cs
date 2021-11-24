//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an operand value of dynamic type
    /// </summary>
    public readonly struct Operand
    {
        public Label Name {get;}

        public dynamic Value {get;}

        [MethodImpl(Inline)]
        public Operand(Label name, dynamic value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Value);

        public override string ToString()
            => Format();
    }
}