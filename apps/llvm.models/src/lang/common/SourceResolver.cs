//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SourceResolver : AppService<SourceResolver>, ISourceResolver
    {
        public TextBlock ResolveSource(ILangSource src)
        {
            if(src is SourceCode sc)
                return sc.Text;
            else if(src is SourceFile sf)
            {
                var path = sf.Location;
                if(path.Exists)
                    return path.ReadUtf8();
                else
                {
                    Error(FS.missing(path));
                    return TextBlock.Empty;
                }
            }
            else
            {
                Error(string.Format("The language {0} is unrecognized", src.LangKind));
                return TextBlock.Empty;
            }
        }
    }
}