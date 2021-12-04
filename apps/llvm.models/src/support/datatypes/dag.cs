//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class dag : IDag<ITerm>
    {
        public ITerm Left {get;}

        public ITerm Right {get;}

        [MethodImpl(Inline)]
        public dag(ITerm left, ITerm right)
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
            => LlvmTypes.format(this);

        public override string ToString()
            => Format();
    }
}

