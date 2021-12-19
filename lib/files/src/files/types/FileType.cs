//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileType : IFileType
    {
        public FileType(string name, params FS.FileExt[] ext)
        {
            Name = name;
            DefaultExtensions = ext;
        }

        public Identifier Name {get;}

        public Index<FS.FileExt> DefaultExtensions {get;}

        public FS.FileExt PrimaryExtension
            => DefaultExtensions.IsNonEmpty ?  DefaultExtensions.First : FS.FileExt.Empty;

        public string Format()
            => PrimaryExtension.Format();


        public override string ToString()
            => Format();
    }
}