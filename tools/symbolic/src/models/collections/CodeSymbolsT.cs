//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.CodeAnalysis;

    using static Root;
    using static core;

    public sealed class CodeSymbols<T> : CodeSymbols<CodeSymbols<T>,T>, ICodeSymbols<T>
        where T : ISymbol
    {
        public CodeSymbols()
        {

        }

        public CodeSymbols(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public CodeSymbols(T[] src)
        {
            Data = src;
        }

        public ref CodeSymbol<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        public new Span<CodeSymbol<T>> Edit
        {
            [MethodImpl(Inline)]
            get => recover<T,CodeSymbol<T>>(base.Edit);
        }

        public new ReadOnlySpan<CodeSymbol<T>> View
        {
            [MethodImpl(Inline)]
            get => recover<T,CodeSymbol<T>>(base.View);
        }

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbols<T>(T[] src)
            => new CodeSymbols<T>(src);
    }
}