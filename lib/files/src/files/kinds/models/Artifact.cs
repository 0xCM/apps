//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Artifact : IArtifact
    {
        public string Classifier {get;}

        public dynamic Location {get;}

        [MethodImpl(Inline)]
        public Artifact(string @class, dynamic locator)
        {
            Classifier = @class;
            Location = locator;
        }

        public string Format()
            => Location;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact((string kind, dynamic locator) src)
            => new Artifact(src.kind, src.locator);
    }
}