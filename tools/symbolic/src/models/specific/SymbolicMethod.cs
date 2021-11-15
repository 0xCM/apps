//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CodeSymbolModels
    {
        public readonly struct SymbolicMethod : ISymbolicArtifact<ClrMethodAdapter,MethodSymbol>
        {
            public ClrMethodAdapter Artifact {get;}

            public MethodSymbol Symbol {get;}

            [MethodImpl(Inline)]
            public SymbolicMethod(ClrMethodAdapter src, MethodSymbol sym)
            {
                Artifact = src;
                Symbol = sym;
            }

            [MethodImpl(Inline)]
            public static implicit operator SymbolicMethod((MethodInfo a, MethodSymbol s) src)
                => new SymbolicMethod(src.a, src.s);
        }
    }
}