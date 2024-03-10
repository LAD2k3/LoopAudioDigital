using LoopAudioDigital.DataAccess;
using LoopAudioDigital.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAudioDigital.Services.implementation
{
    public class SongServices : ISongService
    {
        private readonly ApplicationDbContext _context;
        public SongServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Songs newSong)
        {
            _context.Song.Add(newSong);
            await _context.SaveChangesAsync();
        } 

        public Task DeleteAsync(Songs song)
        {
            _context.Song.Remove(song);
            throw new NotImplementedException();
        }
        public async Task DeleteById(int id)
        {
            var song = GetById(id);
            _context.Remove(song);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Songs> GetAll()
        {
            return _context.Song.ToList();
        }

        public Songs GetById(int id)
        {
            return _context.Song.Where(x => x.songid == id).FirstOrDefault();
        }

        /*public Songs GetByArtistId(string id)
        {
            return _context.Song.Where(x => x.artistid == id).FirstOrDefault();
        }*/

        public async Task UpdateAsSync(Songs newSong)
        {
            _context.Song.Update(newSong);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var song = GetById(id);
            if (song != null)
            {
                _context.Song.Update(song);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Detail(int id)
        {
            var song = GetById(id);
            if (song != null)
            {
                song.listen_count++;
                _context.Song.Update(song);
                await _context.SaveChangesAsync();
            }

        }

    }
}
