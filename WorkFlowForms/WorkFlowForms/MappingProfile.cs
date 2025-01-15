using AutoMapper;
using WorkFlowForms.Common.Model.ViewModel;
using WorkFlowForms.Common.Model.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Doc1ViewModel, Doc1Dto>();
    }
} 