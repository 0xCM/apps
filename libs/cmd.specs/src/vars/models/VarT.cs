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
    public class Var<T> : IVar<Value<T>>
    {
        public Name Name {get;}

        readonly Func<T> Resolver;

        [MethodImpl(Inline)]
        public Var(Name name, Func<T> resolver)
        {
            Name = name;
            Resolver = resolver;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public Value<T> Value
            => Resolver();
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Var(Var<T> src)
            => new Var(src.Name, typeof(T), () => src.Resolver());
    }
}