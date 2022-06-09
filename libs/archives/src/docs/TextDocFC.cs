//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TextDoc<F,C> : Document<F,C,FS.FilePath>
        where F : TextDoc<F,C>, new()
        where C : struct, ITextual
    {
        public TextDoc()
            : base(FS.FilePath.Empty, default(C))
        {

        }

        public TextDoc(C content)
            : base(FS.FilePath.Empty, content)
        {

        }

        public TextDoc(FS.FilePath src, C content)
            : base(src, content)
        {

        }
    }

    public abstract class TextDoc<F> : TextDoc<F,TextBlock>
        where F : TextDoc<F>, new()
    {
        public TextDoc()
            : base(FS.FilePath.Empty, TextBlock.Empty)
        {

        }

        public TextDoc(TextBlock content)
            : base(FS.FilePath.Empty, content)
        {

        }

        public TextDoc(FS.FilePath src, TextBlock content)
            : base(src, content)
        {

        }
    }
}