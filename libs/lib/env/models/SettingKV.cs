//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public sealed class SettingLookup : ConstLookup<VarName,Setting<VarName,string>>
    {
        public SettingLookup(Dictionary<VarName,Setting<VarName,string>> src)
            : base(src)
        {

        }
    }

    public readonly struct Setting<K,V>
    {
        public readonly K Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public Setting(K name, V value)
        {
            Name = name;
            Value = value;
        }
    }
}