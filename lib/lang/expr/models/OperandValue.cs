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
    public readonly struct OperandValue
    {
        public string Name {get;}

        public dynamic Content {get;}

        [MethodImpl(Inline)]
        public OperandValue(string name, dynamic value)
        {
            Name = name;
            Content = value;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Content);

        public override string ToString()
            => Format();
    }
}