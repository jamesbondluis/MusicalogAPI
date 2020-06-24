using AutoMapper;
using BLL;
using DTO;
using System.Collections.Generic;
using System.Web.Http;
using UI.Models;

namespace Musicalog.Controllers
{
    public class AlbumController : ApiController
    {
        private readonly AlbumBLL albumBLL;
        readonly MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<AlbumDTO, Album>();
        });

        readonly MapperConfiguration configDTO = new MapperConfiguration(cfg => {
            cfg.CreateMap<Album, AlbumDTO>();
        });

        public AlbumController()
        {
            albumBLL = new AlbumBLL();
        }

        // GET api/<controller>
        public IEnumerable<Album> Get()
        {
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumBLL.Get());
        }

        // GET api/<controller>/5
        public Album Get(int id)
        {
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<AlbumDTO, Album>(albumBLL.Get(id));
        }

        // POST api/<controller>
        public void Post([FromBody]Album album)
        {
            IMapper iMapper = configDTO.CreateMapper();

            albumBLL.Post(iMapper.Map<Album, AlbumDTO>(album));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Album album)
        {
            IMapper iMapper = configDTO.CreateMapper();

            albumBLL.Put(id, iMapper.Map<Album, AlbumDTO>(album));
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            albumBLL.Delete(id);
        }
    }
}