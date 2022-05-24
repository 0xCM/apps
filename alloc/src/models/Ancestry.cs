//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Ancestry : IEquatable<Ancestry>
    {
        public readonly Index<Label> Ancestors;

        public readonly Label Name;

        public readonly bool IsEmpty;

        // public static Ancestry parse(string src, LabelDispenser dispenser)
        // {
        //     const string sep = "->";
        //     var input = text.trim(src);
        //     if(empty(input))
        //         return Ancestry.Empty;

        //     else if(input.Contains(sep))
        //     {
        //         var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
        //         var count = parts.Length;
        //         if(count == 0)
        //             return Ancestry.Empty;

        //         if(count == 1)
        //         {
        //             var name = dispenser.Label(first(parts));
        //             return new Ancestry(name);
        //         }
        //         else
        //         {
        //             var names = alloc<Label>(count-1);
        //             for(var i=1; i<count; i++)
        //                 seek(names,i-1) = dispenser.Label(skip(parts,i));
        //             return new Ancestry(first(parts), names);
        //         }
        //     }
        //     else
        //         return new Ancestry(input);
        // }

        public bool Equals(Ancestry src)
        {
            if(src is null)
                return false;

            if(object.ReferenceEquals(this,src))
                return true;

            if(!Name.Equals(src.Name))
                return false;

            var count = Ancestors.Length;
            if(count != src.Ancestors.Length)
                return false;

            for(var i=0; i<count; i++)
            {
                if(!Ancestors[i].Equals(src.Ancestors[i]))
                    return false;
            }
            return true;
        }

        internal Ancestry(Label name, Label[] ancestors)
        {
            Name = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        internal Ancestry(Label name)
        {
            Name = name;
            Ancestors = Index<Label>.Empty;
            IsEmpty = false;
        }

        Ancestry()
        {
            Name = EmptyString;
            IsEmpty = true;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.IsNonEmpty;
        }

        public string Format()
            => Format(LeftToRight);

        public string Format(string sep)
        {
            var dst = text.buffer();
            if(IsNonEmpty)
            {
                dst.Append(Name.Format());
                var count = Ancestors.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(sep);
                    dst.Append(Ancestors[i].Format());
                }
            }
            return dst.Emit();

        }

        const string LeftToRight = " -> ";

        public static Ancestry Empty => new Ancestry();
    }
}