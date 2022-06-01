//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPartFiles
    {
        public readonly PartId Part;

        readonly FS.FolderPath Location;

        public ApiPartFiles(PartId part, FS.FolderPath dir)
        {
            Part = part;
            Location = dir;
        }

        public FS.FilePath Asm
            => Location + FS.file(Part.Format(), FS.Asm);

        public FS.FilePath Csv
            => Location + FS.file(Part.Format(), FS.Csv);

        public FS.FilePath Hex
            => Location + FS.file(Part.Format(), FS.Hex);

        public FS.FilePath Bin
            => Location + FS.file(Part.Format(), FS.Bin);
    }
}