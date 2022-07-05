//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        /// <summary>
        /// Defines a conunction of expressions
        /// </summary>
        public readonly struct Product : ISeqExpr<IExprDeprecated>
        {
            readonly Index<IExprDeprecated> Data;

            [MethodImpl(Inline)]
            public Product(IExprDeprecated[] src)
                => Data = src;

            [MethodImpl(Inline)]
            public Product(uint count)
                => Data = sys.alloc<IExprDeprecated>(count);

            public ReadOnlySpan<IExprDeprecated> Terms
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public ref IExprDeprecated First
            {
                [MethodImpl(Inline)]
                get => ref Data.First;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public IExprDeprecated[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public ref IExprDeprecated this[int index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public ref IExprDeprecated this[uint index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Product(IExprDeprecated[] src)
                => new Product(src);
        }
    }
}