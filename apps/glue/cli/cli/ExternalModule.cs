//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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