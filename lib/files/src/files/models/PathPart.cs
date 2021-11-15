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
        /// <summary>
        /// Defines the content of file path component
        /// </summary>
        public readonly struct PathPart : ITextual, IComparable<PathPart>
        {
            public string Text {get;}

            [MethodImpl(Inline)]
            public PathPart(string name)
                => Text = name ?? EmptyString;

            [MethodImpl(Inline)]
            public PathPart(params char[] name)
                => Text = new string(name);

            string TextData
            {
                [MethodImpl(Inline)]
                get => Text ?? EmptyString;
            }

            public uint Length
            {
                [MethodImpl(Inline)]
                get => (uint)TextData.Length;
            }

            public ReadOnlySpan<char> View
            {
                [MethodImpl(Inline)]
                get => TextData;
            }

            [MethodImpl(Inline)]
            public string Format()
                => TextData.Trim();

            [MethodImpl(Inline)]
            public string Format(PathSeparator sep)
                => FS.normalize(Format(), sep);

            [MethodImpl(Inline)]
            public PathPart[] Split(char delimiter)
                => TextData.SplitClean(delimiter).Select(from);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Length == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Length != 0;
            }


            public static PathPart Empty
            {
                [MethodImpl(Inline)]
                get => new PathPart(EmptyString);
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public PathPart Replace(char src, char dst)
                => TextData.Replace(src,dst);

            [MethodImpl(Inline)]
            public PathPart Replace(string src, string dst)
                => TextData.Replace(src,dst);

            public override int GetHashCode()
                => TextData.GetHashCode();

            [MethodImpl(Inline)]
            public bool Equals(PathPart src)
                => string.Equals(TextData, src.TextData, NoCase);

            public override bool Equals(object src)
                => src is PathPart x && Equals(x);

            [MethodImpl(Inline)]
            public PathPart Remove(string substring)
                => TextData.Remove(substring);

            [MethodImpl(Inline)]
            public bool Contains(string substring)
                => TextData.Contains(substring, NoCase);

            [MethodImpl(Inline)]
            public bool StartsWith(string substring)
                => TextData.StartsWith(substring, NoCase);

            /// <summary>
            /// Determines whether the filename, including the extension, ends with a specified substring
            /// </summary>
            /// <param name="substring">The substring to match</param>
            [MethodImpl(Inline)]
            public bool EndsWith(string substring)
                => TextData.EndsWith(substring, NoCase);

            /// <summary>
            /// Determines whether the filename, including the extension, ends with a specified substring
            /// </summary>
            /// <param name="substring">The substring to match</param>
            [MethodImpl(Inline)]
            public bool EndsWith(char c)
                => TextData.EndsWith(c);

            public PathPart RemoveLast()
            {
                if(Length > 0)
                    return new PathPart(Text.Substring(0, (int)Length - 1));
                else
                    return this;
            }

            public int CompareTo(PathPart src)
                => TextData.CompareTo(src.TextData);

            [MethodImpl(Inline)]
            public static bool operator ==(PathPart a, PathPart b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(PathPart a, PathPart b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static implicit operator PathPart(char[] data)
                => new PathPart(data);

            [MethodImpl(Inline)]
            public static implicit operator PathPart(string data)
                => new PathPart(data);

            [MethodImpl(Inline)]
            public static implicit operator string(PathPart data)
                => data.TextData;

            [MethodImpl(Inline)]
            static PathPart from(string src)
                => new PathPart(src);
        }
    }
}