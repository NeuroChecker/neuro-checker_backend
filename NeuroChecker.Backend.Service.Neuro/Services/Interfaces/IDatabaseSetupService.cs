namespace NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

public interface IDatabaseSetupService
{
    Task EnsureDatabaseSetup();
}