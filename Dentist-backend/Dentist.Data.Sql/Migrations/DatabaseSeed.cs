using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;
using Dentist.Data.Sql.DAO;

namespace Dentist.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly DentistDbContext _context;

        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(DentistDbContext context)
        {
            _context = context;
        }

        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        public void Seed()
        {
            #region CreatePatient

            var patientList = BuildPatientList();
            //dodanie pacjentów do tabeli Patient
            _context.Patient.AddRange(patientList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();
            #endregion

            #region CreateDoctor

            var doctorList = BuildDoctorList();
            _context.Doctor.AddRange(doctorList);
            _context.SaveChanges();

            #endregion

            #region CreateAssistant

            var assistantList = BuildAssistantList();
            _context.Assistant.AddRange(assistantList);
            _context.SaveChanges();

            #endregion

            #region CreateAppointment

            var appointmentList = BuildAppointmentList(patientList, doctorList, assistantList);
            _context.Appointment.AddRange(appointmentList);
            _context.SaveChanges();

            #endregion

            #region CreateTreatment

            var treatmentList = BuildTreatmentList();
            _context.Treatment.AddRange(treatmentList);
            _context.SaveChanges();

            #endregion

            #region CreateAppointmentTreatment

            var appointmentTreatmentList = BuildAppointmentTreatmentList(appointmentList, treatmentList);
            _context.AppointmentTreatment.AddRange(appointmentTreatmentList);
            _context.SaveChanges();

            #endregion
        }

        private IEnumerable<DAO.Patient> BuildPatientList()
        {
            var patientList = new List<DAO.Patient>();
            var patient1 = new DAO.Patient()
            {
                PatientName = "Anna",
                PatientSurname = "Mrozek",
                Gender = Gender.Female,
                Pesel = "12345678912",
                BirthDate = new DateTime(2000, 06, 23),
                Phone = "123123123",
                Email = "an.mrozek@student.po.edu.pl",
                City = "Wodzisław Śląski",
                Street = "Bławatkowa",
                HouseNumber = "33A"
            };
            patientList.Add(patient1);

            var patient2 = new DAO.Patient()
            {
                PatientName = "Adriana",
                PatientSurname = "Barteczko",
                Gender = Gender.Female,
                Pesel = "32132165498",
                BirthDate = new DateTime(2000, 05, 25),
                Phone = "123321321",
                Email = "a.barteczko@student.po.edu.pl",
                City = "Wodzisław Śląski",
                Street = "Bławatkowa",
                HouseNumber = "33A"
            };

            patientList.Add(patient2);

            for (int i = 3; i < 20; i++)
            {
                var patient3 = new DAO.Patient()
                {
                    PatientName = "patient" + i,
                    PatientSurname = "patient" + i + i,
                    Gender = i % 2 == 0 ? Gender.Female : Gender.Male,
                    Pesel = (12345678911 + i).ToString(),
                    BirthDate = new DateTime(2000 + i / 2, 01, 25),
                    Phone = (123321321 - i).ToString(),
                    Email = "patient" + i + "@student.po.edu.pl",
                    City = "Wodzisław Śląski",
                    Street = "Bałwankowa",
                    HouseNumber = "3" + i
                };

                patientList.Add(patient3);
            }

            return patientList;
        }

        private IEnumerable<Doctor> BuildDoctorList()
        {
            var doctorList = new List<Doctor>();
            var doctor1 = new Doctor()
            {
                DoctorName = "Adam",
                DoctorSurname = "Kowalski",
                Gender = Gender.Male,
                Phone = "258456951",
                Email = "a.kowalski@stomatolog.poczta.pl",
                Specialization = "Ortodoncja, chirurgia stomatologiczna"
            };
            doctorList.Add(doctor1);

            var doctor2 = new Doctor()
            {
                DoctorName = "Agnieszka",
                DoctorSurname = "Nowak",
                Gender = Gender.Female,
                Phone = "987159357",
                Email = "a.nowak@stomatolog.poczta.pl",
                Specialization = "Ortodoncja, stomatologia dziecięca"
            };

            doctorList.Add(doctor2);

            var doctor3 = new Doctor()
            {
                DoctorName = "Marcin",
                DoctorSurname = "Krzyk",
                Gender = Gender.Male,
                Phone = "691234857",
                Email = "m.krzyk@stomatolog.poczta.pl",
                Specialization = "Stomatologia dziecięca"
            };

            doctorList.Add(doctor3);

            var doctor4 = new Doctor()
            {
                DoctorName = "Katarzyna",
                DoctorSurname = "Bulkiewicz",
                Gender = Gender.Female,
                Phone = "758613489",
                Email = "k.bulkiewicz@stomatolog.poczta.pl",
                Specialization = "Ortodoncja"
            };

            doctorList.Add(doctor4);

            var doctor5 = new Doctor()
            {
                DoctorName = "Krzysztof",
                DoctorSurname = "Nagietek",
                Gender = Gender.Male,
                Phone = "321456987",
                Email = "k.nagietek@stomatolog.poczta.pl",
                Specialization = "Chrurgia stomatologiczna"
            };

            doctorList.Add(doctor5);

            return doctorList;
        }

        private IEnumerable<Assistant> BuildAssistantList()
        {
            var assistantList = new List<Assistant>();
            var assistant1 = new Assistant()
            {
                AssistantName = "Bartosz",
                AssistantSurname = "Kowalski",
                Gender = Gender.Male,
                Email = "b.kowalski@asystent.poczta.pl",
                Phone = "852946321"
            };
            assistantList.Add(assistant1);

            var assistant2 = new Assistant()
            {
                AssistantName = "Karolina",
                AssistantSurname = "Kowalczyk",
                Gender = Gender.Female,
                Email = "k.kowalczyk@asystent.poczta.pl",
                Phone = "111951324"
            };
            assistantList.Add(assistant2);

            var assistant3 = new Assistant()
            {
                AssistantName = "Piotr",
                AssistantSurname = "Listek",
                Gender = Gender.Male,
                Email = "p.listek@asystent.poczta.pl",
                Phone = "111951324"
            };
            assistantList.Add(assistant3);

            return assistantList;
        }

        private IEnumerable<DAO.Appointment> BuildAppointmentList(
            IEnumerable<DAO.Patient> patientList,
            IEnumerable<Doctor> doctorList,
            IEnumerable<Assistant> assistantList)
        {
            var appointmentList = new List<DAO.Appointment>();
            var rand = new Random();
            var patientCount = patientList.ToList().Count;
            var doctorCount = doctorList.ToList().Count;
            var assistantCount = assistantList.ToList().Count;

            foreach (var patient in patientList)
            {
                var patientId = rand.Next(patientCount);
                var doctorId = rand.Next(doctorCount);
                var assistantId = rand.Next(assistantCount);
                appointmentList.Add(new DAO.Appointment
                {
                    PatientId = patientList.ToList()[patientId].PatientId,
                    DoctorId = doctorList.ToList()[doctorId].DoctorId,
                    AssistantId = assistantList.ToList()[assistantId].AssistantId,
                    ApDate = DateTime.Now,
                    ApTime = DateTime.Now
                    //ApDate = DateTime.FromDateTime(DateTime.Now),
                    //ApTime = DateTime.FromDateTime(DateTime.Now),
                });
            }

            return appointmentList;
        }

        private IEnumerable<Treatment> BuildTreatmentList()
        {
            var treatmentList = new List<Treatment>()
            {
                new Treatment
                {
                    TreatmentName = "Konsultacja dentystyczna",
                    Description = "Podstawowa profilaktyka. Obejmuje przegląd jamy ustnej"
                },
                new Treatment
                {
                    TreatmentName = "Ekstrakcja zęba",
                    Description = "Polega na całkowitym usunięciu zęba z jamy ustnej."
                },
                new Treatment
                {
                    TreatmentName = "Hemisekcja",
                    Description = "Polega na usunięciu korzenia z częścią koronową zęba."
                },
                new Treatment
                {
                    TreatmentName = "Endodoncja",
                    Description = "Leczenie kanałowe, polega na usunięciu chorobowo zmienionych tkanek zęba i wypełnieniu powstałej przestrzeni specjelnym materiałem."
                },
                new Treatment
                {
                    TreatmentName = "Lakowanie",
                    Description = "Pokrywanie specjalnym lakiem bruzd znajdujących się na powierzchni zębów. Zabezpiecza zęby przed próchnicą."
                },
                new Treatment
                {
                    TreatmentName = "Skaling",
                    Description = "Polega na usuwaniu kamienia nazębnego, który osadza się głównie w okolicach szyjek zębowych."
                },
                new Treatment
                {
                    TreatmentName = "Wybielanie zębów",
                    Description = "Polega na aktywowaniu specjalnego żelu nałożonego na zęby przez światło akceleratora w celu uzyskania bielszego odcienia zębów."
                }
            };

            return treatmentList;
        }

        private IEnumerable<AppointmentTreatment> BuildAppointmentTreatmentList(
            IEnumerable<DAO.Appointment> appointmentList,
            IEnumerable<Treatment> treatmentList)
        {
            var appointmentTreatmentList = new List<AppointmentTreatment>();

            var rand = new Random();
            var appointmentCount = appointmentList.ToList().Count;
            var treatmentCount = treatmentList.ToList().Count;

            foreach (var appointment in appointmentList)
            {
                var appointmentId = rand.Next(appointmentCount);
                var treatmentId = rand.Next(treatmentCount);
                appointmentTreatmentList.Add(new AppointmentTreatment
                {
                    AppointmentId = appointmentList.ToList()[appointmentId].AppointmentId,
                    TreatmentId = treatmentList.ToList()[treatmentId].TreatmentId
                });
            }

            return appointmentTreatmentList;
        }
    }
}
