using Domain.Calendar;
using Infra.Calendar.Validate;
using System;

namespace Service.Calendar
{
    public interface IGameService
    {
        ErrorMessageList Validate(Game game);
        TimeSpan TimeToRelease(DateTimeOffset release);
    }
}
