using System;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Data.Abstract
{
	public interface IDashboardRepository
	{
		Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
		Task<AppUser> GetUserById(string id);
		Task<AppUser> GetByIdNoTracking(string id);

		bool Update(AppUser user);
		bool Save();
    }
}

