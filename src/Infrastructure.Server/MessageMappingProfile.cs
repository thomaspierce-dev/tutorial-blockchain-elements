namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using AutoMapper;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;

    public class MessageMappingProfile: Profile
    {
        public MessageMappingProfile()
        {
            // Map application messages to domain models
            CreateMap<IBlockSimple, BlockSimpleResponse>()
                .ForMember(dest => dest.BlockNumber, opts => opts.MapFrom(src => src.Number))
                .ForMember(dest => dest.BlockData, opts => opts.MapFrom(src => src.Data))
                .ReverseMap();
        }
    }
}