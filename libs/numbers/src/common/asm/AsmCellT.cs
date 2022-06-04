//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmCell<T> : IAsmSourcePart
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public readonly GridPoint<uint> Location;

        public readonly AsmCellKind PartKind;

        public T Content {get;}

        AsmCellKind IAsmSourcePart.PartKind
            => PartKind;

        [MethodImpl(Inline)]
        public AsmCell(GridPoint<uint> loc, AsmCellKind kind, T data)
        {
            Location = loc;
            Content = data;
            PartKind = kind;
        }

        public string Format()
            => Content == null ? EmptyString : Content.ToString();

        public override string ToString()
            => Format();
    }
}