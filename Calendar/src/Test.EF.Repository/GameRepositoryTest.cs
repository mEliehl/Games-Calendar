using System;
using System.Collections.Generic;
using Domain.Calendar;
using EF.Repository.Calendar;

namespace Test.EF.Repository
{
    public class GameRepositoryTest : BaseRepositoryTest<GameRepository,Game>
    {
        public GameRepositoryTest():base(new GameRepository())
        {
            
        }

        public override IList<Game> CreateTestList()
        {
            var listOfGame = new List<Game>();
            listOfGame.Add(CreateTestObject());
            var game = new Game();
            game.Name = "Forza 6";
            game.Release = new DateTime(2015, 10, 20);
            listOfGame.Add(game);
            return listOfGame;
        }

        public override Game CreateTestObject()
        {
            var game = new Game();
            game.Name = "Halo 5 - Guardians";
            game.Release = new DateTime(2015, 7, 20);
            return game;
        }

        public override Game EditTestObeject(Game entity)
        {
            entity.Name = entity.Name + " Modified";
            return entity;
        }
    }
}
