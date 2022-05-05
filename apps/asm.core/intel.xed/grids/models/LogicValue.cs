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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct LogicValue : ILogicValue<uint>
        {
            [MethodImpl(Inline)]
            public static LogicValue untype<T>(T src)
                where T : unmanaged, ILogicValue<T>
                    => new LogicValue(src.DataKind, src.Size, core.bw32(src.Storage));

            public readonly LogicDataKind DataKind;

            public readonly DataSize Size;

            public readonly uint Storage;

            [MethodImpl(Inline)]
            public LogicValue(LogicDataKind kind, DataSize size, uint data)
            {
                DataKind = kind;
                Size = size;
                Storage = data;
            }

            uint ILogicValue<uint>.Storage
                => Storage;

            LogicDataKind ILogicValue.DataKind
                => DataKind;

            DataSize ILogicValue.Size
                => Size;

            public static LogicValue Empty => default;
        }
    }
}