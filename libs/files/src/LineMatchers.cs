//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct LineMatchers
    {
        [Op]
        public static bool next(ref LineReaderState state, out AsciLineCover<byte> dst)
        {
            dst = AsciLineCover<byte>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;
            var data = text.asci(line).Storage;
            state.LineCount++;

            if(AsciLines.number(data, out var length, out var num))
                dst = new AsciLineCover<byte>(data);
            else
                dst = new AsciLineCover<byte>(data);

            state.Offset+=length;

            return true;
        }

        [Op]
        public static bool next(ref LineReaderState state, out AsciLineCover<char> dst)
        {
            dst = AsciLineCover<char>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;

            var data = line.ToCharArray();
            state.LineCount++;

            if(Digital.number(data, out var length, out var num))
                dst = new AsciLineCover<char>(data);
            else
                dst = new AsciLineCover<char>(data);

            state.Offset+=length;

            return true;
        }

        public static bool next<T>(ref LineReaderState State, Span<byte> buffer, out AsciLineCover<T> dst)
            where T : unmanaged
        {
            dst = AsciLineCover<T>.Empty;
            var _line = State.Source.ReadLine();
            if(_line == null)
                return false;

            var count = AsciSymbols.encode(_line, buffer);
            var data = slice(buffer,0,count);

            State.LineCount++;

            if(AsciLines.number(data, out var length, out var num))
                dst = new AsciLineCover<T>(recover<byte,T>(slice(data, (int)length)));
            else
                dst = new AsciLineCover<T>(recover<byte,T>(data));

            State.Offset+=length;

            return true;
        }

        /// <summary>
        /// Seaches the input for a line-marker sequence
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="markers">The marker sequence</param>
        [Op]
        public static ReadOnlySpan<UnicodeLine> match(ReadOnlySpan<UnicodeLine> src, TextMarkers markers)
        {
            var lCount = src.Length;
            var mCount = markers.Count;
            var dst = list<UnicodeLine>();
            var tmp = list<UnicodeLine>();
            var parts = markers.View;
            for(var i=0; i<lCount; i++)
            {
                for(var j=0; j<mCount && i<lCount; j++, i++)
                {
                    ref readonly var line = ref skip(src,i);
                    if(line.Content.StartsWith(skip(parts,j).Content))
                        tmp.Add(line);
                    else
                    {
                        tmp.Clear();
                        break;
                    }
                }

                if(tmp.Count == mCount)
                    dst.AddRange(tmp);

            }

            return dst.ViewDeposited();
        }

        [Op]
        public static void match(ReadOnlySpan<char> src, char c0, char c1, Action<int> signal)
        {
            var count = src.Length;
            var level = z8;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                            signal(i-level);
                        level = 0;
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
        }

        [Op]
        public static int match(N3 n, ReadOnlySpan<char> src, ReadOnlySpan<char> target)
        {
            var count = src.Length;
            var level = 0;
            ref readonly var c0 = ref skip(target,0);
            ref readonly var c1 = ref skip(target,1);
            ref readonly var c2 = ref skip(target,2);
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                            level++;
                    break;
                    case 2:
                        if(SQ.match(c, c2))
                            return i-level;
                        level = 0;
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return -1;
        }

        [Op]
        public static void match(N3 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker, Action<TextMatch> signal)
        {
            var count = src.Length;
            var seq = span(marker.Content);
            ref readonly var c0 = ref skip(seq,0);
            ref readonly var c1 = ref skip(seq,1);
            ref readonly var c2 = ref skip(seq,2);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var chars = span(line.Content);
                var charcount = chars.Length;
                var level = z8;
                for(var j=0u; j<charcount; j++)
                {
                    ref readonly var c = ref skip(chars, j);
                    switch(level)
                    {
                        case 0:
                            if(SQ.match(c, c0))
                                level++;
                        break;
                        case 1:
                            if(SQ.match(c, c1))
                                level++;
                        break;
                        case 2:
                            if(SQ.match(c, c2))
                                signal(TextMatch.matched(marker, new LineOffset(line.LineNumber,(j-level))));
                            level = 0;
                        break;
                        default:
                            level = 0;
                            break;
                    }
                }
            }
        }

        [Op]
        public static int match(N4 n, ReadOnlySpan<char> src, ReadOnlySpan<char> target)
        {
            var count = src.Length;
            ref readonly var c0 = ref skip(target,0);
            ref readonly var c1 = ref skip(target,1);
            ref readonly var c2 = ref skip(target,2);
            ref readonly var c3 = ref skip(target,3);
            var level = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                            level++;
                    break;
                    case 2:
                        if(SQ.match(c, c2))
                            level++;
                    break;
                    case 3:
                        if(SQ.match(c, c3))
                            return i-level;
                        level = 0;
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return -1;
        }

        [Op]
        public static void match(N4 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker, Action<TextMatch> signal)
        {
            var count = src.Length;
            var seq = span(marker.Content);
            ref readonly var c0 = ref skip(seq,0);
            ref readonly var c1 = ref skip(seq,1);
            ref readonly var c2 = ref skip(seq,2);
            ref readonly var c3 = ref skip(seq,3);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var chars = span(line.Content);
                var charcount = chars.Length;
                var level = z8;
                for(var j=0u; j<charcount; j++)
                {
                    ref readonly var c = ref skip(chars, j);
                    switch(level)
                    {
                        case 0:
                            if(SQ.match(c, c0))
                                level++;
                        break;
                        case 1:
                            if(SQ.match(c, c1))
                                level++;
                        break;
                        case 2:
                            if(SQ.match(c, c2))
                                level++;
                        break;
                        case 3:
                            if(SQ.match(c, c3))
                                signal(TextMatch.matched(marker, new LineOffset(line.LineNumber,(j-level))));
                            level = 0;
                        break;
                        default:
                            level = 0;
                            break;
                    }
                }
            }
        }


        [Op]
        public static int match(N5 n, ReadOnlySpan<char> src, ReadOnlySpan<char> target)
        {
            var count = src.Length;
            var level = 0;
            ref readonly var c0 = ref skip(target,0);
            ref readonly var c1 = ref skip(target,1);
            ref readonly var c2 = ref skip(target,2);
            ref readonly var c3 = ref skip(target,3);
            ref readonly var c4 = ref skip(target,4);
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                            level++;
                    break;
                    case 2:
                        if(SQ.match(c, c2))
                            level++;
                    break;
                    case 3:
                        if(SQ.match(c, c3))
                            level++;
                    break;
                    case 4:
                        if(SQ.match(c, c4))
                            return i-level;
                        level = 0;
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return -1;
        }

        [Op]
        public static void match(N5 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker, Action<TextMatch> signal)
        {
            var count = src.Length;
            var seq = span(marker.Content);
            ref readonly var c0 = ref skip(seq,0);
            ref readonly var c1 = ref skip(seq,1);
            ref readonly var c2 = ref skip(seq,2);
            ref readonly var c3 = ref skip(seq,3);
            ref readonly var c4 = ref skip(seq,4);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var chars = span(line.Content);
                var charcount = chars.Length;
                var level = 0;
                for(var j=0u; j<charcount; j++)
                {
                    ref readonly var c = ref skip(chars, j);
                    switch(level)
                    {
                        case 0:
                            if(SQ.match(c, c0))
                                level++;
                        break;
                        case 1:
                            if(SQ.match(c, c1))
                                level++;
                        break;
                        case 2:
                            if(SQ.match(c, c2))
                                level++;
                        break;
                        case 3:
                            if(SQ.match(c, c3))
                                level++;
                        break;
                        case 4:
                            if(SQ.match(c, c4))
                                signal(TextMatch.matched(marker, new LineOffset(line.LineNumber,(j-4))));
                            level = 0;
                            break;
                        default:
                            level = 0;
                            break;
                    }
                }
            }
        }

        [Op]
        public static void match(N6 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker, Action<TextMatch> signal)
        {
            var count = src.Length;
            var seq = span(marker.Content);
            ref readonly var c0 = ref skip(seq,0);
            ref readonly var c1 = ref skip(seq,1);
            ref readonly var c2 = ref skip(seq,2);
            ref readonly var c3 = ref skip(seq,3);
            ref readonly var c4 = ref skip(seq,4);
            ref readonly var c5 = ref skip(seq,5);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var chars = span(line.Content);
                var charcount = chars.Length;
                var level = z8;
                for(var j=0u; j<charcount; j++)
                {
                    ref readonly var c = ref skip(chars, j);
                    switch(level)
                    {
                        case 0:
                            if(SQ.match(c, c0))
                                level++;
                        break;
                        case 1:
                            if(SQ.match(c, c1))
                                level++;
                        break;
                        case 2:
                            if(SQ.match(c, c2))
                                level++;
                        break;
                        case 3:
                            if(SQ.match(c, c3))
                                level++;
                        break;
                        case 4:
                            if(SQ.match(c, c4))
                                level++;
                        break;
                        case 5:
                            if(SQ.match(c, c5))
                                signal(TextMatch.matched(marker, new LineOffset(line.LineNumber,(j-level))));
                            level = 0;
                            break;
                        default:
                            level = 0;
                            break;
                    }
                }
            }
        }
    }
}