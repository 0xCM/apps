//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct LogicValue<T> : ILogicValue<T>
            where T : unmanaged
        {
            public readonly LogicDataKind DataKind;

            public readonly DataSize Size;

            public readonly T Storage;

            [MethodImpl(Inline)]
            public LogicValue(LogicDataKind kind, DataSize size, T data)
            {
                DataKind = kind;
                Size = size;
                Storage = data;
            }

            T ILogicValue<T>.Storage
                => Storage;

            LogicDataKind ILogicValue.DataKind
                => DataKind;

            DataSize ILogicValue.Size
                => Size;

            [MethodImpl(Inline)]
            public static implicit operator LogicValue(LogicValue<T> src)
                => new LogicValue(src.DataKind, src.Size, core.bw32(src.Storage));

            public static LogicValue<T> Empty => default;
        }
    }
}