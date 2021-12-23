//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IValueCover : IExpr
    {
        dynamic Value {get;set;}

        string ITextual.Format()
            => Value?.ToString() ?? string.Empty;
    }

    public interface IValueCover<T> : IValueCover
    {
       new T Value {get; set;}

        dynamic IValueCover.Value
        {
            get => Value;
            set => Value = (T)value;
        }
    }
}