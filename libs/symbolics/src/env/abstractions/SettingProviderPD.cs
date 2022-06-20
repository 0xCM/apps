//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SettingProvider<P,D> : SettingProvider<P>, ISettingProvider<D>
        where P : SettingProvider<P,D>
        where D : ISetting<D>
    {
        protected Index<D> Data;

        protected SettingProvider(D[] src)
            :base(src.Select(x => new Setting<string,object>(x.Name,x.Value)))
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
    }
}