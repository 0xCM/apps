//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

[assembly: PartId(PartId.Tools)]

namespace Z0.Parts
{
    public sealed partial class Tools : Part<Tools>
    {

    }
}


//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    public readonly struct CodeRepoLink
    {
        public string Http {get;}

        [MethodImpl(Inline)]
        public CodeRepoLink(string http)
        {
            Http = http;
        }

        [MethodImpl(Inline)]
        public static implicit operator CodeRepoLink(string src)
            => new CodeRepoLink(src);
    }


    public readonly struct ExternalModules
    {

    }

    public readonly struct ExternalModule
    {
        public string Name {get;}

        [MethodImpl(Inline)]
        public ExternalModule(string name)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator ExternalModule(string name)
            => new ExternalModule(name);
    }
}