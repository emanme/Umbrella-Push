using Umbrella.Models;

namespace Umbrella.Interfaces
{
    public interface ICredentialRetriever
    {
        Credential GetCredential();
    }
}
