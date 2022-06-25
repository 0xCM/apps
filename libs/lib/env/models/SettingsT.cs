//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Settings<T> : IIndex<Setting<T>>, ILookup<string, Setting<T>>
    {
        public readonly FS.FilePath Source;

        Index<Setting<T>> Data;

        public Settings(Setting<T>[] data)
        {
            Source = FS.FilePath.Empty;
            Data = data;
        }

        public Settings(FS.FilePath src, Setting<T>[] data)
        {
            Source = src;
            Data = data;
        }

        public Setting<T>[] Storage
        {
            get => Data;
        }

        public bool Lookup(string key, out Setting<T> value)
            => Settings.search(this, key, out value);

        public ref Setting<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Setting<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Span<Setting<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<Setting<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public string Format()
        {
            var dst = text.emitter();
            Tables.emit(View,dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}