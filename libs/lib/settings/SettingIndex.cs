//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [ApiHost]
    public class SettingIndex : IIndex<Setting>, ILookup<string,Setting>
    {
        readonly Index<Setting> Data;

        public readonly FS.FilePath Source;

        [MethodImpl(Inline)]
        public SettingIndex(Setting<object>[] data)
        {
            Source = FS.FilePath.Empty;
            Data = data.Select(x => new Setting(x.Name, x.Value));
        }

        [MethodImpl(Inline)]
        public SettingIndex(FS.FilePath src, Setting[] data)
        {
            Source = src;
            Data = data;
        }

        [MethodImpl(Inline)]
        public SettingIndex(Setting[] src)
        {
            Source = FS.FilePath.Empty;
            Data = src;
        }

        public ref Setting this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Setting this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public Setting[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<Setting> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<Setting> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool Find(string key, out Setting value)
            => api.search(this,key,out value);

        public string Format()
        {
            var dst = text.emitter();
            api.render(this, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SettingIndex(Setting<object>[] src)
            => new SettingIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator SettingIndex(Setting[] src)
            => new SettingIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator Setting[](SettingIndex src)
            => src.Storage;

        public static SettingIndex Empty => new SettingIndex(sys.empty<Setting>());
    }
}