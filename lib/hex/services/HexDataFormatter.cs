//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct HexDataFormatter : IHexDataFormatter
    {
        [MethodImpl(Inline), Op]
        public static HexDataFormatter create(ulong? @base = null, ushort bpl = 20, bool labels = true)
            => new HexDataFormatter(new HexLineConfig(bpl, labels), @base);

        public readonly HexLineConfig LineConfig;

        public readonly HexFormatOptions LabelConfig;

        readonly HexFormatOptions DataConfig;

        readonly ulong BaseAddress;

        [MethodImpl(Inline)]
        public HexDataFormatter(HexLineConfig config, ulong? @base = null)
        {
            LineConfig = config;
            BaseAddress = @base ?? 0;
            LabelConfig = HexFormatSpecs.options(zpad:true, specifier: true, uppercase: false, prespec:false);
            DataConfig = HexFormatSpecs.HexData;
        }

        public string FormatLine(ReadOnlySpan<byte> data, ulong offset, char delimiter = Chars.Space)
        {
            var line = TextTools.buffer();
            var count = data.Length;
            if(LineConfig.LineLabels)
            {
                var pos = BaseAddress + offset;
                line.AppendFormat("{0,-12}", pos.ToString("x") + HexFormatSpecs.PostSpec);
                if(delimiter != Space)
                    line.Append(Space);
                line.Append(delimiter);
                if(delimiter != Space)
                    line.Append(Space);
            }

            line.Append(data.FormatHex());

            return line.Emit();
        }

        public void FormatLines(ReadOnlySpan<byte> data, Action<string> receiver)
        {
            var line = TextTools.buffer();
            var count = data.Length;
            var offset = MemoryAddress.Zero;
            for(var i=0u; i<count; i++)
            {
                if(i % LineConfig.BytesPerLine == 0)
                {
                    if(i != 0)
                    {
                        receiver(line.ToString());
                        line.Clear();
                    }

                    if(LineConfig.LineLabels)
                    {
                        line.Append(offset.Format(12));
                        line.Append(LineConfig.Delimiter);
                        line.Append(Chars.Space);
                    }
                }

                line.Append(skip(data,i).FormatHex(DataConfig));
                line.Append(Chars.Space);

                offset += 1;
            }

            var last = line.ToString();
            if(!string.IsNullOrWhiteSpace(last))
                receiver(last);
        }

        public ReadOnlySpan<string> FormatLines(ReadOnlySpan<byte> src)
        {
            const char delimiter = Chars.Space;
            var dst = core.list<string>();
            var line = TextTools.buffer();
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                if(i % LineConfig.BytesPerLine == 0)
                {
                    if(i != 0)
                    {
                        dst.Add(line.Emit());
                    }

                    if(LineConfig.LineLabels)
                    {
                        line.Append(i.FormatHex(LabelConfig));
                        line.Append(delimiter);
                    }
                }

                line.Append(skip(src,i).FormatHex(DataConfig));
                line.Append(delimiter);
            }

            var last = line.Emit();
            if(!string.IsNullOrWhiteSpace(last))
                dst.Add(last);

            return dst.ToArray();
        }
    }
}