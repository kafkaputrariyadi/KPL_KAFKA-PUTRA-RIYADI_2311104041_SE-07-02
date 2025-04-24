using Microsoft.AspNetCore.Mvc;
using tpmodul9_2311104041.Models;

namespace tpmodul9_1302210001.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> listMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Kafka", Nim = "2311104041" },
            new Mahasiswa { Nama = "Farhan Kurniawan", Nim = "1302210002" },
            new Mahasiswa { Nama = "Ahmad Al-Farizi", Nim = "1302210003" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll() => listMahasiswa;

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= listMahasiswa.Count) return NotFound();
            return listMahasiswa[index];
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhs)
        {
            listMahasiswa.Add(mhs);
            return Ok("Mahasiswa ditambahkan");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= listMahasiswa.Count) return NotFound();
            listMahasiswa.RemoveAt(index);
            return Ok("Mahasiswa dihapus");
        }
    }
}
