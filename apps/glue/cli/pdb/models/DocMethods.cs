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

    partial struct PdbModel
    {
        internal readonly struct DocMethods
        {
            public Index<ISymUnmanagedMethod> Methods {get;}

            public ISymUnmanagedDocument Document {get;}

            public DocMethods(ISymUnmanagedDocument doc, ISymUnmanagedMethod[] methods)
            {
                Document = doc;
                Methods = methods;
            }


            public uint MethodCount
            {
                [MethodImpl(Inline)]
                get => Methods.Count;
            }
        }
    }
}