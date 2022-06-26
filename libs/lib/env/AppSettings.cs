//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class AppSettings : Settings<VarName,Setting>
    {
        public AppSettings()
        {

        }

        public AppSettings(Setting[] settings)
            : base(settings.Select(x => new Setting<VarName, Setting>(x.Name,x)))
        {

        }

        public AppSettings(Setting<VarName,Setting>[] settings)
            : base(settings)
        {

        }

        public static AppSettings load(FS.FilePath src)
        {
            var data = src.ReadLines(true);
            var dst = alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line,Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(skip(parts,0)), text.trim(skip(parts,1)));
            }
            return new AppSettings(dst);
        }

        public Setting Find(VarName name)
        {
            var setting = Setting.Empty;
            Find(name, out setting);
            return setting;
        }

        public bool Find(VarName name, out Setting dst)
        {
            var result = base.Find(name, out var x);
            if(result)
                dst = new Setting(name, x.Value);
            else
                dst = Setting.Empty;
            return result;
        }

        public static AppSettings load()
            => load(path());

        public static FS.FilePath path()
            => FS.path(controller().Location).FolderPath + FS.file("app.settings", FileKind.Csv);

        public static string format<T>(in T src)
        {
            var fields = typeof(T).PublicInstanceFields();
            var count = fields.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendLineFormat("{0}:{1}",field.Name, field.GetValue(src));
            }
            return dst.Emit();
        }
    }
}