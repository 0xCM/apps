//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SettingProvider<P,V> : SettingProvider<V>, ISettingProvider<V>
        where P : SettingProvider<P,V>
        where V : ISetting<V>
    {
        protected Index<V> Data;

        protected SettingProvider(V[] src)
            :base(src.Select(x => new Setting<Name,V>(x.Name,x.Value)))
        {
            Data = src;
        }

        public new ref readonly V this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref readonly V this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }
    }
}