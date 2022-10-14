using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {

                var hangHoa = hangHoas.SingleOrDefault(hh=> hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                DonGia = hanghoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hanghoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // update
                hangHoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                hangHoa.DonGia = hanghoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, HangHoa hanghoaDelete)
        {
            try
            {
                var item = hangHoas.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id));
                if (item == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(item);
                   return Ok();
            }
            
            catch
            {
                return BadRequest();
            }
        }
    }
}
