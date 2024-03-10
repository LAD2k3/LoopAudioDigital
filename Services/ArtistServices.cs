using LoopAudioDigital.DataAccess;
using LoopAudioDigital.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LoopAudioDigital.Services.implementation
{
    public class ArtistServices : IArtistService
    {
        private ApplicationDbContext _context;
        public ArtistServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Artists newArtist)
        {
            _context.Artist.Update(newArtist);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Artists artist)
        {
            _context.Artist.Remove(artist);
            throw new NotImplementedException();
        }
        public async Task DeleteById(string id)
        {
            var song = GetById(id);
            _context.Remove(song);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Artists> GetAll()
        {
            return _context.Artist.ToList();
        }

        public Artists GetById(string id)
        {
            return _context.Artist.Where(x => x.Id == id).FirstOrDefault();
        }

        public int NewId(int id)
        {
            id++;
            return id;
        }

        public async Task UpdateAsSync(Artists newArtist)
        {
            _context.Artist.Update(newArtist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(string id)
        {
            var artist = GetById(id);
            if (artist != null)
            {
                _context.Artist.Update(artist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
