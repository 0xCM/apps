//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvSet<EnvVar> : SettingProvider<EnvVar>
    {
        internal EnvSet(VarName name, Setting<VarName,EnvVar>[] settings, Dictionary<VarName,EnvVar> lookup)
            : base(name,settings, lookup)
        {

        }
    }
}