//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Identifies a context-relative scope
    /// </summary>
    public readonly struct ExprScope : IExprScope
    {
        public Label Parent {get;}

        public Label Name {get;}

        [MethodImpl(Inline)]
        public ExprScope(Label parent, Label name)
        {
            Parent = parent;
            Name = name;
        }

        public bool IsRoot
        {
            [MethodImpl(Inline)]
            get => Parent.Length == 0;
        }

        [MethodImpl(Inline)]

        public bool Equals(ExprScope src)
            => Name.Equals(src.Name) && Parent.Equals(src.Parent);

        public string Format()
            => expr.format(this);

        public override string ToString()
            => Format();
    }
}