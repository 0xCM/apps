//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ExprVar : IVar
    {
        public NameOld Name {get;}

        public ExprVar(NameOld name)
        {
            Name = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public IExprDeprecated Eval(IVarResolver context)
            => context.Resolve(Name);

        public T Eval<T>(IVarResolver context)
            where T : IExprDeprecated
                => context.Resolve<T>(Name);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public string Format()
            => Name.Format();

        public override int GetHashCode()
            => Name.GetHashCode();

        public bool Equals(ExprVar src)
            => Name.Equals(src.Name);

        public override bool Equals(object src)
            => src is ExprVar v && Equals(v);
    }
}