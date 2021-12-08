//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;

    public class ToolHelpDoc : IDocument<ToolHelpDoc,TextBlock>
    {
        TextDoc Source;

        public bool IsEmpty {get;}

        public ToolId Tool {get;}

        public string Tag {get;}

        public bool IsNonEmpty
        {
            get => !IsEmpty;
        }

        public ToolHelpDoc()
        {
            IsEmpty = true;
            Tag = EmptyString;
        }

        public ToolHelpDoc(ToolId id, FS.FilePath path)
        {
            Source = new TextDoc(path);
            Tool = id;
            IsEmpty = false;
            Tag = EmptyString;
        }

        ToolHelpDoc(ToolId id, string tag, TextDoc src)
        {
            Tool = id;
            Source = src;
            IsEmpty = false;
            Tag = tag;
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
            => new ToolHelpDoc(Tool, Tag, Source.Load());

        public static ToolHelpDoc Empty => new ToolHelpDoc();
    }
}