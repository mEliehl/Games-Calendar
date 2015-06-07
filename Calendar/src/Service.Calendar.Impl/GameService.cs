using Domain.Calendar;
using Infra.Calendar.Enum;
using Infra.Calendar.Helper;
using Infra.Calendar.Validate;
using Repository.Calendar;
using System;

namespace Service.Calendar.Impl
{
    public class GameService : IGameService
    {
        readonly IGameRepository gameRepository;
        readonly IDateTimeHelper dateTimeHelper;

        public GameService(IGameRepository gameRepository,
            IDateTimeHelper dateTimeHelper)
        {
            this.gameRepository = gameRepository;
            this.dateTimeHelper = dateTimeHelper;
        }

        public TimeSpan TimeToRelease(DateTimeOffset release)
        {
            var ts = new TimeSpan();
            ts = release - dateTimeHelper.Now();
            return ts;
        }

        public ErrorMessageList Validate(Game game)
        {
            var errorMessageList = new ErrorMessageList();

            if (String.IsNullOrWhiteSpace(game.Name))
                errorMessageList.AddError("Name", new ErrorMessage("Name must have a value"));

            if (!string.IsNullOrWhiteSpace(game.Name) && game.Name.Length > 100)
                errorMessageList.AddError("Name", new ErrorMessage("Name text is too large, the limit is 100"));

            if (gameRepository.Any(w => w.Name.Equals(game.Name)))
                errorMessageList.AddError("Name", new ErrorMessage(string.Format("The game {0} has already been registered",game.Name),ErrorType.Warning));

            if (game.Release <= DateTimeOffset.MinValue)
                errorMessageList.AddError("Release", new ErrorMessage("Release must have a value"));

            return errorMessageList;
        }
    }
}
