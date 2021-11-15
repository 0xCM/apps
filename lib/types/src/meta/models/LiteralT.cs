//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a literal value which, by definition, is a labeled constant
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Literal<T> : IExpr
    {
        public Label Name {get;}

        public Constant<T> Value {get;}

        [MethodImpl(Inline)]
        public Literal(Label name, Constant<T> value)
        {
            Name = name;
            Value = value;
        }

        public bool HasName
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Value);

        public override string ToString()
            => Format();
    }
}