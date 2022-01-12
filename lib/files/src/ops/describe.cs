//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    partial struct FS
    {
        [Op]
        public static FileDescription describe(FS.FilePath src)
        {
            var dst = new FileDescription();
            var info = new FileInfo(src.Name);
            dst.Path = src;
            dst.Attributes = info.Attributes;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Size = info.Length;
            return dst;
        }
    }
}