using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Services.Interfaces
{
    public interface ISeederService
    {
        void Run(CancellationToken cancellationToken);
        Task RunAsync(CancellationToken cancellationToken);
    }
}
