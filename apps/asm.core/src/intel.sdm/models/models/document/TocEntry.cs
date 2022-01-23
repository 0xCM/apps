//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack =1), Record(TableId)]
        public struct TocEntry : IRecord<TocEntry>
        {
            public const string TableId ="intel.sdm.toc.entries";

            public const byte FieldCount = 4;

            public VolNumber Volume;

            public SectionNumber Section;

            public ChapterPage Page;

            public CharBlock128 Title;

            [MethodImpl(Inline)]
            public TocEntry(VolNumber vol, in SectionNumber sn, in TocTitle toc)
            {
                Volume = vol;
                Section = sn;
                Page = toc.Page;
                Title = toc.Content;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static TocEntry Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,10,10,1};
        }
    }
}