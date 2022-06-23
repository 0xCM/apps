//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolHelpDoc
    {
        FS.FilePath Source;

        TextBlock Data;

        public readonly bool IsEmpty;

        public readonly ToolId Tool;

        public readonly string Tag;

        public ToolHelpDoc()
        {
            IsEmpty = true;
            Tag = EmptyString;
            Data = EmptyString;
            Source = FS.FilePath.Empty;
        }

        public ToolHelpDoc(ToolId tool, FS.FilePath path)
        {
            Source = path;
            Tool = tool;
            IsEmpty = false;
            Tag = EmptyString;
            Data = EmptyString;
        }

        public ToolHelpDoc(ToolId tool, string tag, FS.FilePath src, TextBlock data)
        {
            Tool = tool;
            Source = src;
            IsEmpty = false;
            Tag = tag;
            Data = data;
        }

        public TextBlock Content
            => Data;

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        public ToolHelpDoc Load()
            => new ToolHelpDoc(Tool, Tag, Source, Source.ReadText());

        public static ToolHelpDoc Empty => new ToolHelpDoc();
    }
}