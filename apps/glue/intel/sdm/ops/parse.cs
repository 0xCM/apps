//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;
    using static SdmModels;

    using SP = ScalarParser;
    using SQ = SymbolicQuery;

    partial class IntelSdm
    {
        [Op]
        public static Outcome row(in TextRow src, out SdmOpCodeDetail dst)
        {
            var result = Outcome.Success;
            var count = src.CellCount;
            var cells = src.Cells;
            dst = default;
            if(src.CellCount != SdmOpCodeDetail.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(SdmOpCodeDetail.FieldCount, src.CellCount));

            var i=0;

            result = DataParser.parse(skip(cells,i++), out dst.OpCodeKey);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.OpCodeKey), skip(cells,i-1)));

            DataParser.block(skip(cells, i++), out dst.Mnemonic);
            DataParser.block(skip(cells, i++), out dst.OpCode);
            DataParser.block(skip(cells, i++), out dst.Sig);
            DataParser.block(skip(cells, i++), out dst.EncXRef);
            DataParser.block(skip(cells, i++), out dst.Mode64);
            DataParser.block(skip(cells, i++), out dst.LegacyMode);
            DataParser.block(skip(cells, i++), out dst.Mode64x32);
            DataParser.block(skip(cells, i++), out dst.CpuId);
            DataParser.block(skip(cells, i++), out dst.Description);
            return result;
        }

        public static Outcome<uint> rows(in TextGrid src, Span<SdmOpCodeDetail> dst)
        {
            var cells = src.Header.Labels.Count;
            if(cells != SdmOpCodeDetail.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(SdmOpCodeDetail.FieldCount, cells));
            return rows(src.Rows, dst);
        }

        [Op]
        public static Outcome<uint> rows(ReadOnlySpan<TextRow> src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = row(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      term.warn(result.Message);
            }
            return (true,counter);
        }

        public static Outcome parse(string src, out TocTitle dst)
        {
            dst = TocTitle.Empty;
            var page = ChapterPage.Empty;
            if(!src.Contains(ContentMarkers.TocTitle, NoCase))
                return false;

            var i = placeholder(src);
            var remainder = text.right(src,i);
            var d = SQ.digitIndex(base10, remainder);
            var input = text.slice(remainder, d);

            if(parse(input, out page))
            {
                dst = title(text.left(src,i), page);
                return true;
            }

            return false;
        }

        public static Outcome parse(string src, out ChapterPage dst)
        {
            dst = ChapterPage.Empty;
            var i = text.index(src, Chars.Dash);
            if(i == NotFound)
                return false;

            var a = text.left(src,i);
            var b = text.right(src,i);
            if(SP.uint8(base10, a, out var cn) && SP.uint16(base10, b, out var pn))
            {
                dst = page(chapter(cn), pn);
                return true;
            }

            return false;
        }

        [Op]
        public static Outcome parse(string src, out ChapterNumber dst)
        {
            dst = ChapterNumber.Empty;
            var i = text.index(src, ContentMarkers.ChapterNumber);
            if(i == NotFound)
                return false;

            var numeric = text.slice(src, i + ContentMarkers.ChapterNumber.Length);
            if(SP.uint8(base10,numeric, out var cn))
            {
                dst = cn;
                return true;
            }

            return false;
        }

        public static Outcome parse(string src, out SectionNumber dst)
        {
            dst = SectionNumber.Empty;
            if(!IsSectionNumber(src))
                return false;

            var digits = text.split(src.ToString(), Chars.Dot);
            var count = digits.Length;
            var result = Outcome.Failure;
            switch(count)
            {
                case 1:
                    if(SP.parse(base10, skip(digits, 0), out dst.A))
                    {
                        dst.Count = 1;
                        result = true;
                    }
                    break;

                case 2:
                        if(
                            SP.parse(base10, skip(digits, 0), out dst.A) &&
                            SP.parse(base10, skip(digits, 1), out dst.B))
                        {
                            dst.Count = 2;
                            result = true;
                        }
                        break;

                case 3: if(
                        SP.parse(base10, skip(digits, 0), out dst.A) &&
                        SP.parse(base10, skip(digits, 1), out dst.B) &&
                        SP.parse(base10, skip(digits, 2), out dst.C))
                        {
                            dst.Count = 3;
                            result = true;
                        }
                        break;

                case 4: if(
                        SP.parse(base10, skip(digits, 0), out dst.A) &&
                        SP.parse(base10, skip(digits, 1), out dst.B) &&
                        SP.parse(base10, skip(digits, 2), out dst.C) &&
                        SP.parse(base10, skip(digits, 3), out dst.D))
                        {
                            dst.Count = 4;
                            result = true;
                        }
                        break;

                default:
                    break;
            }

            return result;
        }

        public static Outcome parse(string src, out TableNumber dst)
        {
            const char DigitSep = Chars.Dash;
            const char NumberEnd = Chars.Dot;
            dst = TableNumber.Empty;
            var i = index(src, ContentMarkers.TableNumber);
            if(i != NotFound)
            {
                dst = tablenumber(text.slice(src, i + ContentMarkers.TableNumber.Length));
                return true;
            }
            return false;
        }

        [Op]
        public static Outcome parse(string src, out TableTitle dst)
        {
            dst = TableTitle.Empty;
            var result = Outcome.Success;
            result = parse(src, out dst.Table);
            if(!result)
                return result;

            var i = index(src, ContentMarkers.TableNumber);
            dst.Label = text.left(src, i + ContentMarkers.TableNumber.Length).Trim();
            return result;
        }

        [Op]
        static bool IsSectionNumber(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            if(count == 0)
                return false;

            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.digit(base10,c))
                    continue;

                if(c == Chars.Dot)
                    continue;

                return false;
            }
            return true;
        }
    }
}