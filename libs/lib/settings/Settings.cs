//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class Settings : IIndex<Setting>, ILookup<string,Setting>
    {
        [MethodImpl(Inline)]
        public static Setting empty()
            => Setting.Empty;

        public static Name name(Type src)
            => src.Tag<ConfigAttribute>().MapValueOrElse(tag => tag.Name, () => (Name)src.DisplayName());

        public static Name name<T>()
            => name(typeof(T));

        public static FS.FilePath path()
            => FS.path(ExecutingPart.Component.Location).FolderPath + FS.file($"{ExecutingPart.Id.Format()}.settings", FileKind.Csv);

        public static FS.FilePath path(FS.FolderPath dir, string name, FileKind kind)
            => dir + FS.file(name, kind);

        public static Outcome single<T>(FS.FilePath src, char sep, out T dst)
            where T : new()
        {
            var result = Outcome.Success;
            dst = new();
            if(!src.Exists)
                return (false, FS.missing(src));
            return Settings.single(src.ReadLines(), sep, out dst);
        }

        public static Outcome single<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var settings = parse(src);
            var result = Outcome.Success;
            var fields = typeof(T).PublicInstanceFields().Select(x => (x.Name,x)).ToDictionary();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                if(setting.IsEmpty)
                    continue;

                if(fields.TryGetValue(setting.Name, out var field))
                {
                    var type = field.FieldType;
                    result = Settings.parse(setting.Format(sep), type, out var s);
                    if(result.Fail)
                        break;
                    field.SetValue(dst, s.Value);
                }
            }
            return result;
        }

        public static string json(Setting src)
            => string.Concat(text.enquote(src.Name), Chars.Colon, Chars.Space, src.ValueText.Enquote());

        const NumericKind Closure = UnsignedInts;

        [Op]
        public static bool search(in Settings src, Name key, out Setting value)
        {
            value = Setting.Empty;
            var result = false;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                if(string.Equals(setting.Name, key, NoCase))
                {
                    value = setting;
                    result = true;
                }
            }
            return result;
        }

        readonly Index<Setting> Data;

        public readonly FS.FilePath Source;

        [MethodImpl(Inline)]
        public Settings(Setting<object>[] data)
        {
            Source = FS.FilePath.Empty;
            Data = data.Select(x => new Setting(x.Name, x.Value));
        }

        [MethodImpl(Inline)]
        public Settings(FS.FilePath src, Setting[] data)
        {
            Source = src;
            Data = data;
        }

        [MethodImpl(Inline)]
        public Settings(Setting[] src)
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
            => search(this,key,out value);

        public string Format()
        {
            var dst = text.emitter();
            render(this, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Settings(Setting<object>[] src)
            => new Settings(src);

        [MethodImpl(Inline)]
        public static implicit operator Settings(Setting[] src)
            => new Settings(src);

        [MethodImpl(Inline)]
        public static implicit operator Setting[](Settings src)
            => src.Storage;

        public static Settings Empty => new Settings(sys.empty<Setting>());
    }
}