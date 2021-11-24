//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    public struct ExprVar<K,T>
        where K : unmanaged
    {
        public K Name {get;}

        IVarBinder<K,T> Binder;

        public T Value
             => Binder.Bind(Name);

        public ExprVar(K name, IVarBinder<K,T> binder)
        {
            Name = name;
            Binder = binder;
        }

        public string Placeholder(uint pos)
            => text.enclose(string.Format("{0}:{1}", pos, Value), Fencing.Dirac);

        public string Format()
            => text.enclose(string.Format("{0}:{1}", Name, Value), Fencing.Dirac);

        public override string ToString()
            => Format();
    }
}