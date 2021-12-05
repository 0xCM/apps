//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCsvPaths
    {
        public FS.FilePath AsmPath {get;}

        public FS.FilePath CsvPath {get;}

        [MethodImpl(Inline)]
        public AsmCsvPaths(FS.FilePath asm, FS.FilePath csv)
        {
            AsmPath = asm;
            CsvPath = csv;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out FS.FilePath asm, out FS.FilePath csv)
        {
            asm = AsmPath;
            csv = CsvPath;
        }
        public string Format()
            => string.Format("{0} -> {1}", AsmPath.ToUri(), CsvPath.ToUri());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCsvPaths((FS.FilePath asm, FS.FilePath csv) src)
            => new AsmCsvPaths(src.asm, src.csv);
    }
}