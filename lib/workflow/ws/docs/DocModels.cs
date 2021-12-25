//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    public readonly struct DocModels
    {
        public static UnicodeDoc unicode(char[] src)
            => new UnicodeDoc(src);

        public static AsciDoc asci(AsciSymbol[] src)
            => new AsciDoc(src);

        public static UnicodeDoc unicode(FS.FilePath src)
            => unicode(File.ReadAllText(src.Format()).ToCharArray());

        public abstract class Doc
        {
            public uint LineCount {get; protected set;}
        }

        public struct DocReader<K>
            where K : unmanaged, IEquatable<K>
        {
            readonly Doc<K> Doc;

            uint CellPos;

            uint TermPos;

            internal DocReader(Doc<K> doc)
            {
                Doc = doc;
                CellPos = 0;
                TermPos = 0;
            }

            [MethodImpl(Inline)]
            public uint Count(K match)
            {
                var counter = 0u;
                var cells = Doc.Cells;
                var count = cells.Length;
                for(var i=0; i<count; i++)
                    if(skip(cells,i).Equals(match))
                        counter++;
                return counter;
            }

            [MethodImpl(Inline)]
            public bool ReadUntil(K match, out ReadOnlySpan<K> dst)
            {
                var cells = Doc.Cells;
                var count = cells.Length;
                if(CellPos < count)
                {
                    var i0=CellPos;
                    for(var j=CellPos; j<count; CellPos++)
                    {
                        if(skip(cells,j).Equals(match))
                        {
                            dst = slice(cells,i0, j - i0);
                            return true;
                        }
                    }
                }
                dst = default;
                return false;
            }
        }

        public abstract class Doc<K> : Doc
            where K : unmanaged, IEquatable<K>
        {
            public Doc(K[] src)
            {
                Data = src;
            }

            Index<K> Data;

            public ReadOnlySpan<K> Cells
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public DocReader<K> CreateReader()
                => new DocReader<K>(this);
        }

        public sealed class UnicodeDoc : Doc<char>
        {
            public UnicodeDoc(char[] src)
                : base(src)
            {
                LineCount = Lines.count(src);
            }

        }

        public sealed class AsciDoc : Doc<AsciSymbol>
        {
            public AsciDoc(AsciSymbol[] src)
                : base(src)
            {

            }
        }
    }
}