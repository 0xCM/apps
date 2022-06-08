//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct EnvVars// : IIndex<EnvVar>
    {
        public static EnvVars load()
            => new (Z0.Env.vars().ToArray());

        public static Index<EnvVarRecord> records(EnvVars src)
        {
            var dst = alloc<EnvVarRecord>(src.Count);
            for(var i=0; i<src.Count; i++)
                seek(dst,i) = new EnvVarRecord(src[i].Name,src[i].Value);
            return dst;
        }

        public static EnvVarSet set(FS.FilePath src)
        {
            var result = Outcome.Success;
            var dst = new EnvVarSet();
            dst.Source = src;
            dst.Name = text.left(src.FileName.Format(), Chars.Dot);
            dst.Vars = new();

            var vars = list<EnvVar>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var i = text.index(content,Chars.Eq);
                if(i > 0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    vars.Add((name,value));
                }
            }
            dst.Vars = vars;

            return dst;
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