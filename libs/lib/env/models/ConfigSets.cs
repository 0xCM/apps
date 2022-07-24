//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigSets
    {
        public static SettingIndex app()
            => Settings.rows(ConfigPaths.app());

        public static SettingIndex cmd()
            => Settings.rows(ConfigPaths.cmd());
    }
}