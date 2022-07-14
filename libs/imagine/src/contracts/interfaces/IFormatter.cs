//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate string RenderDelegate<T>(T src);

    [Free]
    public delegate string FormatterDelegate(dynamic src);

    [Free]
    public interface IFormatter
    {
        string Format(dynamic src);

        Type SourceType {get;}

        FormatterDelegate Delegate => Format;
    }

    [Free]
    public interface IFormatter<T> : IFormatter
    {
        string Format(T src);

        new RenderDelegate<T> Delegate => Format;

        FormatterDelegate IFormatter.Delegate
            => x => Format((T)x);

        string IFormatter.Format(dynamic src)
            => Format((T)src);

        Type IFormatter.SourceType
            => typeof(T);
    }
}