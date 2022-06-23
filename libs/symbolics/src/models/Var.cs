//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    /// <summary>
    /// Defines a variable
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Var : IVar
    {
        public Name Name {get;}

        readonly Func<dynamic> Resolver;

        public Type ValueType {get;}

        [MethodImpl(Inline)]
        public Var(Name name, Type t, Func<dynamic> resolver)
        {
            Name = name;
            ValueType = t;
            Resolver = resolver;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        [MethodImpl(Inline)]
        public Value<dynamic> Resolve()
            => new Value<dynamic>(Resolver());

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}