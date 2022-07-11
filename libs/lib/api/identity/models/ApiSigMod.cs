//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiSigMod : IApiSigMod<ApiSigMod>
    {
        public NameOld Name {get;}

        public ApiSigModKind Kind {get;}

        public ApiSigMod(NameOld name, ApiSigModKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public string Format()
            => Name;

        public override string ToString()
            => Format();
    }
}