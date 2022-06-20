//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MachineEnv : SettingProvider<Setting<string,object>>
    {
        public MachineEnv(Setting<string,object>[] src)
            : base(src.Select(x => new Setting<string,object>(x.Name,x.Value)))
        {
        }
    }
}