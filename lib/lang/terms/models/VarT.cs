//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Terms;

    /// <summary>
    /// Defines a variable
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Var<T> : IVar<Value<T>>
    {
        public VarSymbol Name {get;}

        readonly Func<T> Resolver;

        [MethodImpl(Inline)]
        public Var(string name, Func<T> resolver)
        {
            Name = name;
            Resolver = resolver;
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