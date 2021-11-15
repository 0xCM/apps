//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    using R = BitMaskInfo;

    public readonly struct BitMaskFormatter
    {
        readonly IRecordFormatter<R> Formatter;

        readonly ITextBuffer Buffer;

        public static BitMaskFormatter create()
            => new BitMaskFormatter(Tables.formatter<R>());

        BitMaskFormatter(IRecordFormatter<R> formatter)
        {
            Formatter = formatter;
            Buffer = text.buffer();
        }

        public string Format(in R src)
        {
            Buffer.Clear();
            Buffer.Delimit(Formatter.FormatSpec.Header.Delimiter,
                string.Format("{0,-30}", src.Name),
                string.Format("{0,-10}", src.Base),
                string.Format("{0,-80}", format(base2, src)),
                string.Format("{0,-80}", src.Text));
            return Buffer.Emit();
        }

        public string HeaderText
            => Formatter.FormatHeader();

        static string format(Base2 @base, BitMaskInfo src)
            => BitRender.format(src.Data, src.TypeCode);
    }
}