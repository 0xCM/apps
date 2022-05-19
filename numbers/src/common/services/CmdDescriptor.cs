//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdDescriptor
    {
        public @string Scope {get;}

        public @string Name {get;}

        public CmdDescriptor(string scope, string name)
        {
            Scope = scope;
            Name = name;
        }

        public static implicit operator CmdDescriptor((string scope, string name) src)
            => new CmdDescriptor(src.scope, src.name);
    }
}