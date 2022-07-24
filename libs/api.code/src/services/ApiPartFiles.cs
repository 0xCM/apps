//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPartFiles
    {
        public static ApiPartFiles create(IApiPack src, PartId part)
            => new ApiPartFiles(part, src);

        public readonly PartId Part;

        readonly IApiPack Location;

        public ApiPartFiles(PartId part, IApiPack dir)
        {
            Part = part;
            Location = dir;
        }

        public FS.FilePath Asm
            => Location.AsmExtractPath(Part);

        public FS.FilePath Csv
            => Location.CsvExtractPath(Part);

        public FS.FilePath Hex
            => Location.HexExtractPath(Part);
    }
}