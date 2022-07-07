//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiLoader
    {
        public static FS.FolderPath location()
            => FS.path(core.controller().Location).FolderPath;
    }
}