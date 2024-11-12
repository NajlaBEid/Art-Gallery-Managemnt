using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Art_Gallery_Management.Models.Exhibitions;
using Art_Gallery_Management.Models.Managers;
using AutoMapper;

namespace Art_Gallery_Management.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();
            CreateMap<AddArtist, Artist>();
            CreateMap<UpdateArtist, Artist>();


            CreateMap<Manager, ManagerDto>();
            CreateMap<ManagerDto, Manager>();
            CreateMap<AddManager, Manager>();
            CreateMap<UpdateManager, Manager>();

            CreateMap<Exhibition, ExhibitionDto>();
            CreateMap<ExhibitionDto, Exhibition>();
            CreateMap<AddExhibition, Exhibition>();
            CreateMap<UpdateExhibition, Exhibition>();

            CreateMap<ArtWork, ArtWorkDto>();
            CreateMap<ArtWorkDto, ArtWork>();
            CreateMap<AddArtWork, ArtWork>();
            CreateMap<UpdateArtWork, ArtWork>();    

        
        }
    }
}
