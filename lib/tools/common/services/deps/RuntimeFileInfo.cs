//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public struct RuntimeFileInfo
        {
            public FS.FilePath Path;

            public string AssemblyVersion;

            public string FileVersion;

            public void Render(ITextBuffer dst)
            {
                if(Path.IsNonEmpty)
                    dst.Append(Format());
            }

            public string Format()
            {
                if(Path.IsNonEmpty)
                {
                    if(text.nonempty(AssemblyVersion))
                        return string.Format("{0}, {1}", Path.ToUri(), AssemblyVersion);
                    else
                        return Path.ToUri().Format();
                }
                return string.Empty;
            }
        }
    }
}