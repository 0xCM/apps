//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        public readonly record struct LogicValue : ILogicValue<uint>
        {
            [MethodImpl(Inline)]
            public static LogicValue untype<T>(T src)
                where T : unmanaged, ILogicValue<T>
                    => new LogicValue(src.DataKind, src.DataWidth, core.bw32(src.Storage));

            public readonly LogicDataKind DataKind;

            public readonly byte DataWidth;

            public readonly uint Storage;

            [MethodImpl(Inline)]
            public LogicValue(LogicDataKind kind, byte width, uint data)
            {
                DataKind = kind;
                DataWidth = width;
                Storage = data;
            }

            uint ILogicValue<uint>.Storage
                => Storage;

            LogicDataKind ILogicValue.DataKind
                => DataKind;

            byte ILogicValue.DataWidth
                => DataWidth;
        }
    }
}