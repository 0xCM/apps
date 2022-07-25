//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigSets
    {
        public static SettingLookup app()
            => Settings.rows(ConfigPaths.app());

        public static SettingLookup cmd()
            => Settings.rows(ConfigPaths.cmd());
    }
}