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

    partial struct Lines
    {
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
        public static bool next(ref LineReaderState state, out AsciLine<byte> dst)
        {
            dst = AsciLine<byte>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;
            var data = text.asci(line).Storage;
            state.LineCount++;

            if(Lines.number(data, out var length, out var number))
                dst = new AsciLine<byte>(number, data);
            else
                dst = new AsciLine<byte>(state.LineCount, data);

            state.Offset+=length;

            return true;
        }

        [Op]
        public static bool next(ref LineReaderState state, out AsciLine<char> dst)
        {
            dst = AsciLine<char>.Empty;
            var line = state.Source.ReadLine();
            if(line == null)
                return false;

            var data = line.ToCharArray();
            state.LineCount++;

            if(Lines.number(data, out var length, out var number))
                dst = new AsciLine<char>(number, data);
            else
                dst = new AsciLine<char>(state.LineCount, data);

            state.Offset+=length;

            return true;
        }

        public static bool next<T>(ref LineReaderState State, Span<byte> buffer, out AsciLine<T> dst)
            where T : unmanaged
        {
            dst = AsciLine<T>.Empty;
            var _line = State.Source.ReadLine();
            if(_line == null)
                return false;

            var count = AsciSymbols.encode(_line, buffer);
            var data = slice(buffer,0,count);

            State.LineCount++;

            if(Lines.number(data, out var length, out var number))
                dst = new AsciLine<T>(number, recover<byte,T>(slice(data, (int)length)).ToArray());
            else
                dst = new AsciLine<T>(State.LineCount, recover<byte,T>(data).ToArray());

            State.Offset+=length;

            return true;
        }

    }
}