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

    public interface ISymbolicArtifact<R,S>
        where R : IClrRuntimeObject
        where S : ICodeSymbol
    {
        R Artifact {get;}

        S Symbol {get;}
    }
}