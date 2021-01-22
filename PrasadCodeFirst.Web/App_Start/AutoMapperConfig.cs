using AutoMapper;

namespace PrasadCodeFirst.Web
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.AddProfile<ApiMappingProfile>();
        }
    }
}