using LoopAudioDigital.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAudioDigital.Services
{
    public interface IArtistService
    {
        Task CreateAsSync(Artists newArrtist);
        Task UpdateById(string id);
        Task UpdateAsSync(Artists newArtist);
        Task DeleteById(string id);
        Artists GetById(string id);
        IEnumerable<Artists> GetAll();
        int NewId(int id);
        Task DeleteAsync(Artists artist);
        //IEnumerable<SelectListItem> GetAllArtistsForPayroll();

    }
}
