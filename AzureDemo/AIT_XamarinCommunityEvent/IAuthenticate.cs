using System.Threading.Tasks;

namespace AIT_XamarinCommunityEvent
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
}

