//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class EnvProvider<P,D> : EnvProvider<P>, IEnvProvider<D>
        where P : EnvProvider<P,D>
        where D : IEnvVar
    {
        protected Index<D> Data;

        protected EnvProvider(D[] src)
            :base(src.Select(x => new EnvVar(x.Name,x.Value)))
        {
            Data = src;
        }


        public new ref readonly D this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref readonly D this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref readonly Index<D> Vars
        {
            [MethodImpl(Inline)]
            get => ref Data;
        }

    }
}