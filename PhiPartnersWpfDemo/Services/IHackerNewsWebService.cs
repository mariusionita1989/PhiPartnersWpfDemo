using PhiPartnersWpfDemo.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhiPartnersWpfDemo.Services
{
    public interface IHackerNewsWebService
    {
        Task<List<StoryDto>?> GetBestStoriesAsync();
    }
}
