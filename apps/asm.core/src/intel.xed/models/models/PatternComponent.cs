//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct PatternComponent : IEquatable<PatternComponent>
        {
            public static Index<PatternComponent> components(string src)
                => core.map(text.split(src, Chars.Space), x => (PatternComponent)x);

            public readonly @string Value;

            [MethodImpl(Inline)]
            public PatternComponent(string src)
            {
                Value = src;
            }

            [MethodImpl(Inline)]
            public string Format()
                => Value;

            public override string ToString()
                => Format();

            public bool Equals(PatternComponent src)
                => Value.Equals(src.Value);

            public override int GetHashCode()
                => (int)alg.hash.marvin(Value.Value);

            public override bool Equals(object src)
                => src is PatternComponent c && Equals(c);

            [MethodImpl(Inline)]
            public static implicit operator PatternComponent(string src)
                => new PatternComponent(src);
        }
    }
}