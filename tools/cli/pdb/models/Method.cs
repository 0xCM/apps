//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.DiaSymReader;

    using static Root;

    using api = PdbServices;

    partial struct PdbModel
    {
        public readonly struct Method : IAppSymAdapter<Method, ISymUnmanagedMethod>
        {
            internal readonly ISymUnmanagedMethod Source;

            [MethodImpl(Inline)]
            internal Method(ISymUnmanagedMethod src)
            {
                Source = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Source == null;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Source != null;
            }

            public CliToken Token
            {
                [MethodImpl(Inline)]
                get => api.token(this);
            }

            public ReadOnlySpan<SequencePoint> SequencePoints
            {
                [MethodImpl(Inline)]
                get => api.points(Source);
            }

            public ReadOnlySpan<Document> Documents
            {
                [MethodImpl(Inline)]
                get => api.documents(Source);
            }

            public PdbMethodInfo Describe()
            {
                var dst = new PdbMethodInfo();
                dst.Token = Token;
                dst.SequencePoints = api.points(Source);
                dst.Documents = api.documents(Source);
                return dst;
            }

            [MethodImpl(Inline)]
            public static bool operator true(Method src)
                => src.IsNonEmpty;

            [MethodImpl(Inline)]
            public static bool operator false(Method src)
                => src.IsEmpty;
        }
    }
}