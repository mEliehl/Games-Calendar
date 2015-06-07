using Domain.Calendar;
using Microsoft.Data.Entity;
using Repository.Calendar;

namespace EF.Repository.Calendar
{
    public class GameRepository :BaseRepository<Game>, IGameRepository
    {
        
    }
}
