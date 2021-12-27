//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class dag : IDag<IExpr>
    {
        public IExpr Left {get;}

        public IExpr Right {get;}

        [MethodImpl(Inline)]
        public dag(IExpr left, IExpr right)
        {
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsEmpty && Right.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNonEmpty && Right.IsNonEmpty;
        }

        public string Format()
            => Format(DagFormatStyle.List);

        public string Format(DagFormatStyle style)
            => LlvmTypes.format(this, style);

        public override string ToString()
            => Format();
    }
}