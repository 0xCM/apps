//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISetting<K,V> : ISetting<V>
        where K : unmanaged, IAsciSeq<K>
    {
        new SettingName<K> Name {get;}

        string ISetting.Name
            => Name.ToString();
    }
}