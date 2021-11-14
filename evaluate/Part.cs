//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;
using System.Reflection;

[assembly: AssemblyDescription("Evaluating here instead of everywhere else")]
[assembly: PartId(PartId.Evaluate)]

namespace Z0.Parts
{        
    public sealed class Evaluate : Part<Evaluate> { }
}