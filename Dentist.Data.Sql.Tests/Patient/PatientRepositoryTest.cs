using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Dentist.Common.Enums;
using Dentist.Data.Sql.Patient;
using Dentist.IData.Patient;

namespace Dentist.Data.Sql.Tests.Patient
{
    public class PatientRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private DentistDbContext _context;
        private IPatientRepository _patientRepository;

        public PatientRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DentistDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost; userid=root; pwd=root; port=3306; database=dentist_db;");
            _context = new DentistDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _patientRepository = new PatientRepository(_context);
        }

        [Fact]
        public async Task AddPatient_Returns_Correct_Response()
        {
            var patient = new Domain.Patient.Patient("Name", "Surname", Gender.Male, "11111111111", DateTime.UtcNow, "111111111", "Email", "City", "Street", "11");
            var patientId = await _patientRepository.AddPatient(patient);

            var createdPatient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == patientId);
            Assert.NotNull(createdPatient);

            _context.Patient.Remove(createdPatient);
            await _context.SaveChangesAsync();
        }
    }
}
