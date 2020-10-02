using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Data
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
