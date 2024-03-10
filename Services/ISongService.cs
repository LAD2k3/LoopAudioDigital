using LoopAudioDigital.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAudioDigital.Services
{
    public interface ISongService
    {
        Task CreateAsSync(Songs newSong);
        Task UpdateById(int id);
        Task UpdateAsSync(Songs newSong);
        Task DeleteById(int id);
        Task Detail(int id);
        Songs GetById(int id);
        /*Songs GetByArtistId(string id);*/
        Task DeleteAsync(Songs song);
        IEnumerable<Songs> GetAll();
        //IEnumerable<SelectListItem> GetAllSongsForPayroll();

    }
}
