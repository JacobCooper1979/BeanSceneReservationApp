using BeanSceneReservationApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeanSceneReservationApp.Services
{
    public interface IMemberService
    {
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> CreateMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
    }
}
