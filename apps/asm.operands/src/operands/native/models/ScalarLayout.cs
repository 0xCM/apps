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
            if(src.ContentWidth == src.StorageWidth)
                dst = string.Format("{0}{1}", src.ContentWidth, NativeTypes.indicator(src.Class));
            else
                dst = string.Format("({0}:{1}){2}", src.ContentWidth, src.StorageWidth, NativeTypes.indicator(src.Class));
            return dst;
        }

        public readonly ushort ContentWidth;

        public readonly ushort StorageWidth;

        public readonly ScalarClass Class;

        [MethodImpl(Inline)]
        public ScalarLayout(ushort content, ushort storage, ScalarClass @class)
        {
            ContentWidth = content;
            StorageWidth = storage;
            Class = @class;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static ScalarLayout Empty => default;
    }
}