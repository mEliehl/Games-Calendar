using Domain.Calendar;
using FluentValidation.Results;
using System;

namespace Service.Calendar
{
    public interface IGameService
    {
        ValidationResult Validate(Game game);
        TimeSpan TimeToRelease(DateTime release);
    }
}
