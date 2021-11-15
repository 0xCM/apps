//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public sealed class AppSettings : AppService<AppSettings>
    {
        public Settings Load(FS.FilePath src)
        {
            var dst = Settings.Empty;
            try
            {
                dst = Settings.parse(src.ReadLines());
            }
            catch(Exception e)
            {
                Error(e);
            }
            return dst;
        }

        public Settings Load(ReadOnlySpan<TextLine> src)
        {
            var dst = Settings.Empty;
            try
            {
                dst = Settings.parse(src);
            }
            catch(Exception e)
            {
                Error(e);
            }

            return dst;
        }
    }
}