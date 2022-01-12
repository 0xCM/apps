//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        public readonly struct RelativePath : IFsEntry<RelativePath>
        {
            public PathPart Name {get;}

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public RelativePath(PathPart name)
            {
                if(name.IsNonEmpty)
                {
                    ref readonly var c = ref core.first(name.Text);
                    if(c == (char)PathSeparator.BS || c == (char)PathSeparator.FS)
                        Name = text.slice(name.Text,1);
                    else
                        Name = name;
                }
                else
                {
                    Name = PathPart.Empty;
                }
            }

            [MethodImpl(Inline)]
            public RelativePath Replace(char src, char dst)
                => new RelativePath(Name.Replace(src,dst));

            [MethodImpl(Inline)]
            public RelativePath Replace(string src, string dst)
                => new RelativePath(Name.Replace(src,dst));

            [MethodImpl(Inline)]
            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public string Format(PathSeparator sep, bool quote = false)
                => quote ? text.enquote(Name.Format(sep)) : Name.Format(sep);

            [MethodImpl(Inline)]
            public static RelativePath operator +(RelativePath a, RelativePath b)
                => relative(Z0.text.format("{0}/{1}", a.Name, b.Name));

            [MethodImpl(Inline)]
            public static RelativePath operator +(RelativePath a, FolderName b)
                => relative(Z0.text.format("{0}/{1}", a.Name, b.Name));

            [MethodImpl(Inline)]
            public static RelativePath operator +(FolderName a, RelativePath b)
                => relative(Z0.text.format("{0}/{1}", a.Name, b.Name));

            [MethodImpl(Inline)]
            public static FS.FolderPath operator +(FolderPath a, RelativePath b)
                => FS.dir(Z0.text.format("{0}/{1}", a.Name, b.Name));

            [MethodImpl(Inline)]
            public static RelativeFilePath operator +(RelativePath a, FileName b)
                => new RelativeFilePath(relative(Z0.text.format("{0}/{1}", a.Name, b.Name)));

            public static RelativePath Empty
            {
                [MethodImpl(Inline)]
                get => new RelativePath(PathPart.Empty);
            }
        }
    }
}