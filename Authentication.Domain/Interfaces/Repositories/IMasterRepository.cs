using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Interfaces.Repositories
{
    public interface IMasterRepository
    {
        Task SaveAsync(CancellationToken cancellation);
    }
}
