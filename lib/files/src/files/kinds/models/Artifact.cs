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

        public string Locator {get;}

        [MethodImpl(Inline)]
        public Artifact(string @class, string locator)
        {
            Classifier = @class;
            Locator = locator;
        }

        public string Format()
            => Locator;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact((string kind, string locator) src)
            => new Artifact(src.kind, src.locator);
    }
}