using BeanSceneReservationApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationApp.Services
{
    public class MemberService 
    {

    //    private readonly BeanSeanReservationDbContext _context;

    //    public MemberService(BeanSeanReservationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Member> GetMemberByIdAsync(int memberId)
    //    {
    //        return await _context.Members.FindAsync(memberId);
    //    }

    //    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    //    {
    //        return await _context.Members.ToListAsync();
    //    }


    //    public async Task<bool> CreateMemberAsync(Member member)
    //    {
    //        try
    //        {
    //            _context.Members.Add(member);
    //            await _context.SaveChangesAsync();
               
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            return false;
    //        }
           
    //    }

    //    public async Task<Member> UpdateMemberAsync(Member member)
    //    {
    //        _context.Members.Update(member);
    //        await _context.SaveChangesAsync();
    //        return member;
    //    }

    //    public async Task<bool> DeleteMemberAsync(int memberId)
    //    {
    //        var member = await _context.Members.FindAsync(memberId);
    //        if (member == null)
    //        {
    //            return false;
    //        }

    //        _context.Members.Remove(member);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }

    }
}
