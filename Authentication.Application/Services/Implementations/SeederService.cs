using Authentication.Application.Services.Interfaces;
using Authentication.Domain.Interfaces.Repositories;

namespace Authentication.Application.Services.Implementations
{
    public class SeederService(IEnumerable<ISeederRepository> seederRepositories) : ISeederService
    {
        public void Run()
        {
            foreach (var seeder in seederRepositories)
                seeder.Run();
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            foreach (var seeder in seederRepositories)
                await seeder.RunAsync(cancellationToken);
        }
    }
}
