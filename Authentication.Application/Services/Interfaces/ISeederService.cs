using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Services.Interfaces
{
    public interface ISeederService
    {
        void Run();
        Task RunAsync(CancellationToken cancellationToken);
    }
}
