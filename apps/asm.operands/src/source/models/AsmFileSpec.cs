//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmFileSpec
    {
        public Identifier Name {get;}

        public Index<IAsmSourcePart> Parts {get;}

        [MethodImpl(Inline)]
        public AsmFileSpec(Identifier name, IAsmSourcePart[] parts)
        {
            Name = name;
            Parts = parts;
        }

        public string Format()
            => AsmRender.file(this);

        public override string ToString()
            => Format();

        public FS.FilePath Path(FS.FolderPath dst)
            => dst + FS.file(Name.Format(), FS.Asm);

        public FS.FilePath Save(FS.FolderPath dst)
        {
            var path = Path(dst);
            Save(path);
            return path;
        }

        public uint Save(FS.FilePath dst)
        {
            using var writer = dst.AsciWriter();
            writer.WriteLine(Format());
            return Parts.Count;
        }
    }
}