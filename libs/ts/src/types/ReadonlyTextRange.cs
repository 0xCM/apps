//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    public interface IReadonlyTextRange
    {
        uint pos {get;}

        uint end {get;}
    }

    public interface IReadonlyTextRange<T> : IReadonlyTextRange
        where T : IReadonlyTextRange<T>, new()
    {

    }

    public record class ReadOnlyTextRange : IReadonlyTextRange<ReadOnlyTextRange>
    {
        public readonly uint pos;

        public readonly uint end;
    }
}