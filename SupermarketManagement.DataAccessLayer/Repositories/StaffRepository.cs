using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.GenericRepository;
using SupermarketManagement.DataAccessLayer.IRepositories;

namespace SupermarketManagement.DataAccessLayer.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
    }

}
