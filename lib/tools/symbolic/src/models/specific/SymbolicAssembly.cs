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

    partial struct CaSymbolModels
    {
        public readonly struct SymbolicAssembly : ICaSymbolArtifact<ClrAssemblyAdapter,AssemblySymbol>
        {
            public ClrAssemblyAdapter Artifact {get;}

            public AssemblySymbol Symbol {get;}

            [MethodImpl(Inline)]
            public SymbolicAssembly(ClrAssemblyAdapter a, AssemblySymbol s)
            {
                Artifact = a;
                Symbol = s;
            }

            [MethodImpl(Inline)]
            public static implicit operator SymbolicAssembly((Assembly a, AssemblySymbol s) src)
                => new SymbolicAssembly(src.a, src.s);
        }
    }
}