//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class ToolHelpDoc
    {
        FS.FilePath Source;

        TextBlock Data;

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
            Data = EmptyString;
            Source = FS.FilePath.Empty;
        }

        public ToolHelpDoc(ToolId id, FS.FilePath path)
        {
            Source = path;
            Tool = id;
            IsEmpty = false;
            Tag = EmptyString;
            Data = EmptyString;
        }

        ToolHelpDoc(ToolId id, string tag, FS.FilePath src, TextBlock data)
        {
            Tool = id;
            Source = src;
            IsEmpty = false;
            Tag = tag;
            Data = data;
        }

        public TextBlock Content
            => Data;


        public string Format()
        {
            return Content;
        }

        public ToolHelpDoc Load()
            => new ToolHelpDoc(Tool, Tag, Source, Source.ReadText());

        public static ToolHelpDoc Empty => new ToolHelpDoc();
    }
}