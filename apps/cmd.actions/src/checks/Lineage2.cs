//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Lineage2 : IEquatable<Lineage2>
    {
        public static Lineage2 parse(string src, LabelDispenser dispenser)
        {
            const string sep = "->";
            var input = text.trim(src);
            if(empty(input))
                return Lineage2.Empty;

            else if(input.Contains(sep))
            {
                var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
                var count = parts.Length;
                if(count == 0)
                    return Lineage2.Empty;

                if(count == 1)
                {
                    var name = dispenser.Dispense(first(parts));
                    return new Lineage2(name);
                }
                else
                {
                    var names = alloc<Label>(count-1);
                    for(var i=1; i<count; i++)
                        seek(names,i-1) = dispenser.Dispense(skip(parts,i));
                    return new Lineage2(first(parts), names);
                }
            }
            else
                return new Lineage2(input);
        }

        public bool Equals(Lineage2 src)
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

        Lineage2(Label name, Label[] ancestors)
        {
            Name = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        Lineage2(Label name)
        {
            Name = name;
            Ancestors = Index<Label>.Empty;
            IsEmpty = false;
        }

        Lineage2()
        {
            Name = EmptyString;
            IsEmpty = true;
        }


        public Index<Label> Ancestors {get;}

        public Label Name {get;}

        public bool IsEmpty {get;}

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

       public static Lineage2 Empty => new Lineage2();
    }
}