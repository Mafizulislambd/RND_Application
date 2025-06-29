using HomeRentTracker.Models.RenterEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HomeRentTracker.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllAsync();
            return View(members);
        }

        public async Task<IActionResult> Details(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null) return NotFound();
            return View(member);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(MemberInfo member)
        {
            int renterID = 0;
            string renterNID = string.Empty;

            if (renterID == 0|| string.IsNullOrEmpty(renterNID))
            {  renterID=member.RenterID != null ? Convert.ToInt32(member.RenterID) : 0;
                renterNID = member.RenterNID ?? string.Empty;
                // Assuming you have a way to get the current renter ID, e.g., from session or user context
                // renterID = GetCurrentRenterId(); // Implement this method as per your logic
            }
            if (ModelState.IsValid)
            {
              int memberID=  await _memberService.AddAsync(member, renterID, renterNID);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MemberInfo member)
        {
            if (ModelState.IsValid)
            {
                await _memberService.UpdateAsync(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
