//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VarSymbol<T> : IVarSymbol<T>
        where T : unmanaged, ICharBlock<T>
    {
        public readonly Name<T> Name;

        [MethodImpl(Inline)]
        public VarSymbol(Name<T> name)
        {
            Name = name;
        }

        Name<T> IVarSymbol<T>.Name
            => Name;

        T INamed<T>.Name => throw new NotImplementedException();
    }
}