//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClrComponentInfo : IRecord<ClrComponentInfo>
    {
        public const string TableId = "clr.components";

        public FS.FilePath ImgPath;

        public FS.FilePath PdbPath;

        public FS.FilePath XmlPath;

        public ByteSize MetadatSize;
    }
}