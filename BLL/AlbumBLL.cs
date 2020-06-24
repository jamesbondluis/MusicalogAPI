using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class AlbumBLL
    {
        readonly AlbumDAL albumDAL;

        public AlbumBLL()
        {
            albumDAL = new AlbumDAL();
        }

        public IEnumerable<AlbumDTO> Get()
        {
            return albumDAL.Get();
        }

        public AlbumDTO Get(int id)
        {
            return albumDAL.Get(id);
        }

        public void Post(AlbumDTO album)
        {
            albumDAL.Post(album);
        }

        public void Put(int id, AlbumDTO album)
        {
            albumDAL.Put(id, album);
        }

        public void Delete(int id)
        {
            albumDAL.Delete(id);
        }
    }
}
