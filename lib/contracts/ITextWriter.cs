//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITextWriter : IDisposable
    {
        IFormatProvider FormatProvider {get;}

        string NewLine {get;}

        void Close();

        void Flush();

        void Write(bool value);

        void Write(char value);

        void Write(char[]? buffer);

        void Write(char[] buffer, int index, int count);

        void Write(decimal value);

        void Write(double value);

        void Write(int value);

        void Write(long value);

        void Write(object? value);

        void Write(ReadOnlySpan<char> buffer);

        void Write(float value);

        void Write(string? value);

        void Write(string format, object? arg0);

        void Write(string format, object? arg0, object? arg1);

        void Write(string format, object? arg0, object? arg1, object? arg2);

        void Write(string format, params object?[] arg);

        void Write(StringBuilder? value);

        void Write(uint value);

        void Write(ulong value);

        Task WriteAsync(char value);
    }
}