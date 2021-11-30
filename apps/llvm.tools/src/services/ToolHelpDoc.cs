//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    public class ToolHelpDoc : IDocument<ToolHelpDoc,TextBlock>
    {
        TextDoc Source;

        public bool IsEmpty {get;}

        public bool IsNonEmpty
        {
            get => !IsEmpty;
        }


        public ToolHelpDoc()
        {
            IsEmpty = true;
        }

        public ToolHelpDoc(FS.FilePath path)
        {
            Source = new TextDoc(path);
            IsEmpty = false;
        }

        ToolHelpDoc(TextDoc src)
        {
            Source = src;
            IsEmpty = false;
        }

        public TextBlock Content
            => Source.Content;

        public ILocatable Location
        {
            get => Source.Location;
        }

        public string Format()
        {
            return Content;
        }

        public ToolHelpDoc Load()
            => new ToolHelpDoc(Source.Load());

        public static ToolHelpDoc Empty => new ToolHelpDoc();
    }
}