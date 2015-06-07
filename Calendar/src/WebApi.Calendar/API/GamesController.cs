using Domain.Calendar;
using Microsoft.AspNet.Mvc;
using Repository.Calendar;
using Service.Calendar;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Calendar.API
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        readonly IGameRepository gameRepository;
        readonly IGameService gameService;
        readonly IUnitOfWorkFactory unitOfWorkFactory;

        public GamesController(IGameRepository gameRepository,
            IGameService gameService,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.gameRepository = gameRepository;
            this.gameService = gameService;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
        
        // GET: api/values
        [HttpGet]
        public async Task<IList<Game>> Get()
        {
            using (var uow = unitOfWorkFactory.Create(ApplicationContextEnum.Calendar))
            {
                //var guid = Guid.NewGuid();
                //for (int i = 0; i < 100000; i++)
                //{
                //    var game = await gameRepository.GetByIdAsync(1);
                //    System.Diagnostics.Debug.WriteLine(guid + " " + game.Name + " " + i);
                //}
                return await gameRepository.GetAsync(w => true);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var uow = unitOfWorkFactory.Create(ApplicationContextEnum.Calendar))
            {
                var game = await gameRepository.GetByIdAsync(id);
                if (game == null)
                    return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

                return new ObjectResult(game); 
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Game game)
        {
            using (var uow = unitOfWorkFactory.Create(ApplicationContextEnum.Calendar))
            {
                gameRepository.Add(game);
                await uow.SaveChangesAsync();
                return new HttpStatusCodeResult((int)HttpStatusCode.OK); 
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Game game)
        {
            using (var uow = unitOfWorkFactory.Create(ApplicationContextEnum.Calendar))
            {
                var model = await gameRepository.GetByIdAsync(id);
                if (model == null)
                {
                    return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                model.Name = game.Name;
                gameRepository.Update(model);
                await uow.SaveChangesAsync();
                return new HttpStatusCodeResult((int)HttpStatusCode.OK); 
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (var uow = unitOfWorkFactory.Create(ApplicationContextEnum.Calendar))
            {
                gameRepository.Remove(id);
                await uow.SaveChangesAsync();
                return new HttpStatusCodeResult((int)HttpStatusCode.OK); 
            }
        }
    }
}
