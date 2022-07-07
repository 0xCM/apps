//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigSets
    {
        public static Settings app()
            => Settings.load(ConfigPaths.app());

        public static Settings cmd()
            => Settings.load(ConfigPaths.cmd());
    }
}