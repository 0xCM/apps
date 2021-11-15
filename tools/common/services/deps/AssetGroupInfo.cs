//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public struct AssetGroupInfo
        {
            public string Runtime;

            public Index<FS.FilePath> AssetPaths;

            public Index<RuntimeFileInfo> RuntimeFiles;

            public void Render(ITextBuffer dst)
            {
                if(AssetPaths.Count != 0)
                {
                    dst.AppendLine("assets:");
                    core.iter(AssetPaths, p => dst.AppendLine(string.Format("{0}", p.ToUri())));
                }

                if(RuntimeFiles.Count != 0)
                {
                    dst.AppendLine("runtime_files:");
                    core.iter(RuntimeFiles, f => dst.AppendLine(string.Format("{0}", f.Format())));
                }
            }
        }
    }
}