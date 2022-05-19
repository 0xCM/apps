//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ScalarLayout
    {
        [Formatter]
        public static string format(ScalarLayout src)
        {
            var dst = EmptyString;
            if(src.PackedWidth == src.NativeWidth)
                dst = string.Format("{0}{1}", src.PackedWidth, NativeTypes.indicator(src.Class));
            else
                dst = string.Format("({0}:{1}){2}", src.PackedWidth, src.NativeWidth, NativeTypes.indicator(src.Class));
            return dst;
        }

        public readonly ushort PackedWidth;

        public readonly ushort NativeWidth;

        public readonly NativeClass Class;

        [MethodImpl(Inline)]
        public ScalarLayout(ushort content, ushort storage, NativeClass @class)
        {
            PackedWidth = content;
            NativeWidth = storage;
            Class = @class;
        }

        public DataSize Size
        {
            [MethodImpl(Inline)]
            get => (PackedWidth,NativeWidth);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static ScalarLayout Empty => default;
    }
}