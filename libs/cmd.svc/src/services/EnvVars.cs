//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    using EN = SettingNames;

    public readonly struct EnvVars : IIndex<EnvVar>
    {
        public static EnvVars Empty => new EnvVars(sys.empty<EnvVar>());

        public static void emit(WfEmit emitter, SysEnvKind kind, FS.FolderPath dst)
        {
            var vars = EnvVars.Empty;
            switch(kind)
            {
                case SysEnvKind.Machine:
                    vars = EnvVars.machine();
                break;
                case SysEnvKind.Process:
                    vars = EnvVars.process();
                break;
                case SysEnvKind.User:
                    vars = EnvVars.user();
                break;
            }
            if(vars.IsNonEmpty)
            {
                vars.Iter(v => emitter.Write(v.Format()));
                EnvVars.emit(emitter, vars, kind, dst);
            }
        }

        public static EnvVars emit(SysEnvKind kind, bool display = true)
        {
            var archives = ProjectArchives.load(Settings.rows(AppSettings.path()));
            var dir = Settings.setting(archives.Path(EN.EnvConfig), FS.dir).Value;
            var vars = EnvVars.vars(kind);
            var name =  $"{ExecutingPart.Name}.{EnumRender.format(kind)}";
            if(display)
                term.write(vars, FlairKind.Babble);
            //emit(emitter, records(vars, name).View, dir + FS.file($"{name}.settings", FileKind.Csv), ASCI);
            FS.emit(typeof(EnvVars), vars, dir + FS.file(name, FileKind.Env), ASCI);
            return vars;
        }

        public static ExecToken emit(WfEmit emitter, EnvVars src, SysEnvKind kind, FS.FolderPath dst)
        {
            var name =  $"{ExecutingPart.Name}.{EnumRender.format(kind)}";
            var table = dst + FS.file($"{name}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}", FileKind.Env);
            using var writer = env.AsciWriter();
            for(var i=0; i<src.Count; i++)
                writer.WriteLine(src[i].Format());
            return emit(emitter, records(src, name).View, table, ASCI);
        }

        static ExecToken emit<T>(WfEmit emitter, ReadOnlySpan<T> src, FS.FilePath dst, TextEncodingKind encoding, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = " | ")
            where T : struct
        {
            var emitting = emitter.EmittingTable<T>(dst);
            var formatter = RecordFormatters.create<T>(rowpad, fk, delimiter);
            using var writer = dst.Emitter(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<src.Length; i++)            
                writer.WriteLine(formatter.Format(skip(src,i)));            
            return emitter.EmittedTable(emitting, src.Length);

        }

        public static EnvVars vars(SysEnvKind kind)
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables((EnvironmentVariableTarget)kind))
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }

        public static EnvVars machine()
            => vars(SysEnvKind.Machine);

        public static EnvVars user()
            => vars(SysEnvKind.User);

        public static EnvVars process()
            => vars(SysEnvKind.Process);

        public static Index<EnvVarRow> records(EnvVars src, string name)
        {
            const char Sep = ';';
            var buffer = list<EnvVarRow>();
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var v = ref src[i];
                var vName = v.VarName.Format();
                var vValue = v.VarValue;

                if(v.Contains(Sep))
                {
                    var parts = text.split(vValue,Sep).Index();
                    for(var j=0; j<parts.Count; j++)
                    {
                        ref readonly var part = ref parts[j];
                        var dst = new EnvVarRow();
                        dst.Seq = k++;
                        dst.EnvName = name;
                        dst.VarName = vName;
                        dst.VarValue = part;
                        dst.Join = Sep.ToString();
                        buffer.Add(dst);
                    }
                }
                else
                {
                    var dst = new EnvVarRow();
                    dst.Seq = k++;
                    dst.EnvName = name;
                    dst.VarName = vName;
                    dst.VarValue = vValue;
                    dst.Join = EmptyString;
                    buffer.Add(dst);
                }
            }

            return buffer.ToIndex();
        }

        Index<EnvVar> Data {get;}

        [MethodImpl(Inline)]
        public EnvVars(EnvVar[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }
        public EnvVar[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<EnvVar> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<EnvVar> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref EnvVar this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref EnvVar this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public string Format()
        {
            var dst = text.buffer();
            var src = View;
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(EnvVar[] src)
            => new EnvVars(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(List<EnvVar> src)
            => new EnvVars(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar[](EnvVars src)
            => src.Storage;
    }
}