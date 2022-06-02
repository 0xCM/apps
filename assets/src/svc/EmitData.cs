//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    partial class Assets
    {
        public ResEmission EmitData(in Asset src, FS.FolderPath dir)
        {
            var dst = dir + src.FileName;
            AppSvc.FileEmit(utf8(src), dst, TextEncodingKind.Utf8);
            return flows.arrow(src,dst);
        }
    }
}