//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvSet<S> : SettingProvider<EnvSet<S>>, ISettingProvider
        where S : struct
    {
        readonly ConstLookup<string,object> Data;

        public EnvSet(string name, S src, Setting<string,object>[] settings)
            : base(settings)
        {
            Name = name;
            Data = settings.Select(x => (x.Name,x.Value)).ToDictionary();
        }

        public override string Name {get;}
    }
}