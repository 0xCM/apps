//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack =1), Record(TableId)]
        public struct TocEntry : IRecord<TocEntry>
        {
            public const string TableId ="intel.sdm.toc-entries";

            public SectionNumber Section;

            public TocTitle Title;

            [MethodImpl(Inline)]
            public TocEntry(in SectionNumber sn, in TocTitle toc)
            {
                Section = sn;
                Title = toc;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static TocEntry Empty => default;
        }
    }
}