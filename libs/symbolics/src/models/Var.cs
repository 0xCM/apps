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

        readonly Func<object> Resolver;

        public Type ValueType {get;}

        [MethodImpl(Inline)]
        public Var(Name name, Type t, Func<object> resolver)
        {
            Name = name;
            ValueType = t;
            Resolver = resolver;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Name);
        }

        [MethodImpl(Inline)]
        public Value<object> Resolve()
            => new Value<object>(Resolver());

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}