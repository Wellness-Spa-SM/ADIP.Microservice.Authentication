using Authentication.Application.Services.Interfaces;
using TM.Common.Utils.Interfaces;

namespace Authentication.Application.Services.Implementations
{
    public class SeederService(IEnumerable<ISeeder> seederRepositories) : ISeederService
    {
        public void Run(CancellationToken cancellationToken)
        {
            foreach (var seeder in seederRepositories)
                seeder.Run(cancellationToken);
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            foreach (var seeder in seederRepositories)
                await seeder.RunAsync(cancellationToken);
        }
    }
}
