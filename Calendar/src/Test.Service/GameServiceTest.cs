using Domain.Calendar;
using Service.Calendar;
using Service.Calendar.Impl;
using System;
using System.Text;
using Test.Service.Fakes;
using Xunit;
using System.Linq;
using Infra.Calendar.Enum;

namespace Test.Service
{

    public class GameServiceTest
    {
        readonly IGameService gameService;
        private FakeGameRepository fakeGameRepository;

        public GameServiceTest()
        {
            fakeGameRepository = new FakeGameRepository();
            this.gameService = new GameService(fakeGameRepository, new DateTimeHelperFake());
        }

        private Game CreateValidGame()
        {
            var game = new Game();
            game.Name = "Forza 6";
            game.Release = new DateTime(2015, 10, 20);
            return game;
        }

        [Fact]
        public void TimeToReleaseTest()
        {
            var game = CreateValidGame();
            double expected = 0d;
            var actual = gameService.TimeToRelease(game.Release);
            Assert.Equal(expected , actual.TotalDays);            
        }

        [Fact]
        public void ValidateSuccessTest()
        {
            var game = CreateValidGame();
            var expected = gameService.Validate(game);
            Assert.Empty(expected);
        }

        [Fact]
        public void ValidateFailNameNullTest()
        {
            var game = CreateValidGame();
            game.Name = null;
            var expected = gameService.Validate(game);
            Assert.True(expected.ContainsKey("Name"));
        }

        [Fact]
        public void ValidateFailNameEmptyTest()
        {
            var game = CreateValidGame();
            game.Name = string.Empty;
            var expected = gameService.Validate(game);
            Assert.True(expected.ContainsKey("Name"));
        }

        [Fact]
        public void ValidateFailNameMaxLengthTest()
        {
            var game = CreateValidGame();
            var sb = new StringBuilder();
            for (int i = 0; i < 101; i++)
                sb.Append('a');
            game.Name = sb.ToString();
            var expected = gameService.Validate(game);
            Assert.True(expected.ContainsKey("Name"));
        }

        [Fact]
        public void ValidateWaringNameAlreadyBeenRegisteredTest()
        {
            fakeGameRepository.AnyReturn = true;
            var game = CreateValidGame();
            var expected = gameService.Validate(game);
            Assert.True(expected.ContainsKey("Name"));
            fakeGameRepository.AnyReturn = false;
        }

        [Fact]
        public void ValidateFailReleaseInvalidTest()
        {
            var game = CreateValidGame();
            game.Release = new DateTimeOffset();
            var expected = gameService.Validate(game);
            Assert.True(expected.ContainsKey("Release"));
        }
    }
}
