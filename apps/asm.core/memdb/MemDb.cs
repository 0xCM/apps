//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class MemDb : IDisposable, IMemDbInternal
    {
        public static MemDb open()
            => new MemDb();

        readonly Alloc Alloc;

        readonly DbSvc _DbSvc;

        MemDb()
        {
            Alloc = Alloc.allocate();
            _DbSvc = DbSvc.create(this);

        }

        ref readonly Alloc IMemDbInternal.Alloc
            => ref Alloc;


        public ref readonly DbSvc Services
        {
            [MethodImpl(Inline)]
            get => ref _DbSvc;
        }

        public void Dispose()
        {
            Alloc.Dispose();
        }
    }

    internal interface IMemDbInternal
    {
        ref readonly Alloc Alloc {get;}
    }
}