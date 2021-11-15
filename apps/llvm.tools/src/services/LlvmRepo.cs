//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static LlvmNames;

    public class LlvmRepo : AppService<LlvmRepo>
    {
        FS.Files _BuildOutput;

        FS.Files _AllFiles;

        public LlvmRepo()
        {
            _BuildOutput = FS.Files.Empty;
            _AllFiles = FS.Files.Empty;
        }

        public FS.FolderPath Root()
            => Env.LlvmRoot;

        public FS.Files Files()
        {
            if(_AllFiles.IsEmpty)
                _AllFiles = Root().AllFiles;
            return _AllFiles;
        }

        public FS.Files Files(FS.FileExt ext)
            => Files().Where(f => f.Is(ext));

        public FS.Files BuildOutput()
        {
            if(_BuildOutput.IsEmpty)
                _BuildOutput = (BuildRoot()).AllFiles;
            return _BuildOutput;
        }

        public FS.FolderPath BuildRoot()
            => Root() + FS.folder(Repo.build);

        public FS.Files BuildOutput(FS.FileExt ext)
            =>  BuildOutput().Where(x => x.Is(ext));

        public FS.Files BuildOutput(FS.FileExt a, FS.FileExt b)
            =>  BuildOutput().Where(x => x.Is(a) || x.Is(b));
    }
}