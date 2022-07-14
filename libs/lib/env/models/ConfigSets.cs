//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigSets
    {
        public static Settings app()
            => Settings.rows(ConfigPaths.app());

        public static Settings cmd()
            => Settings.rows(ConfigPaths.cmd());
    }
}