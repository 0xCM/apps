//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        public readonly record struct LogicValue<T> : ILogicValue<T>
            where T : unmanaged
        {
            public readonly LogicDataKind DataKind;

            public readonly byte DataWidth;

            public readonly T Storage;

            [MethodImpl(Inline)]
            public LogicValue(LogicDataKind kind, byte width, T data)
            {
                DataKind = kind;
                DataWidth = width;
                Storage = data;
            }

            T ILogicValue<T>.Storage
                => Storage;

            LogicDataKind ILogicValue.DataKind
                => DataKind;

            byte ILogicValue.DataWidth
                => DataWidth;

            [MethodImpl(Inline)]
            public static implicit operator LogicValue(LogicValue<T> src)
                => new LogicValue(src.DataKind, src.DataWidth, core.bw32(src.Storage));
        }
    }
}