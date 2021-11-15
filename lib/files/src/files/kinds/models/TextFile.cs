//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TextFile<F,C> : Document<F,C,FS.FilePath>
        where F : TextFile<F,C>, new()
        where C : struct, ITextual
    {
        public TextFile()
            : base(FS.FilePath.Empty, default(C))
        {

        }

        public TextFile(C content)
            : base(FS.FilePath.Empty, content)
        {

        }

        public TextFile(FS.FilePath src, C content)
            : base(src, content)
        {

        }
    }

    public abstract class TextFile<F> : TextFile<F,TextBlock>
        where F : TextFile<F>, new()
    {

        public TextFile()
            : base(FS.FilePath.Empty, TextBlock.Empty)
        {

        }

        public TextFile(TextBlock content)
            : base(FS.FilePath.Empty, content)
        {

        }

        public TextFile(FS.FilePath src, TextBlock content)
            : base(src, content)
        {

        }
    }

    // public sealed class TextFile : TextFile<TextFile>
    // {
    //     public TextFile()
    //         : base(FS.FilePath.Empty, TextBlock.Empty)
    //     {

    //     }

    //     public TextFile(TextBlock content)
    //         : base(FS.FilePath.Empty, content)
    //     {

    //     }

    //     public TextFile(FS.FilePath src, TextBlock content)
    //         : base(src, content)
    //     {

    //     }

    //     public override TextFile Load(FS.FilePath location)
    //         => new TextFile(location, location.ReadText());
    // }
}