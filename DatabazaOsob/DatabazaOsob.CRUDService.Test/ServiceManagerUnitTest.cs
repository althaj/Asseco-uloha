using DatabazaOsob.CRUDService.DTO;
using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.CRUDService.Service;

namespace DatabazaOsob.CRUDService.Test
{
    [TestClass]
    public sealed class ServiceManagerUnitTest
    {
        OsobaDTO testOsoba = new OsobaDTO
        {
            Jmeno = "Test Jmeno",
            Prijmeni = "Test Prijmeni",
            Narodnost = "Slovenská",
            DatumNarozeni = new DateTime(2024, 4, 1),
            RodneCislo = "9504097372",
            Bydliste = new BydlisteDTO
            {
                Mesto = "Trenčín",
                PSC = "91322",
                Stat = "Slovenská republika",
                Ulice = "Saratovská 11"
            },
            Kontakty = new List<KontaktDTO>
                {
                    new KontaktDTO
                    {
                        Hodnota = "123",
                        TypKontaktu = "Telefon"
                    },
                    new KontaktDTO
                    {
                        Hodnota = "a@a.com",
                        TypKontaktu = "Email"
                    }
                }
        };

        [TestMethod]
        public void CreateOsobaTest()
        {
            ServiceManager serviceManager = new ServiceManager($"UnitTest_{Guid.NewGuid()}.db");

            OsobaDTO resultOsoba = serviceManager.CreateOsoba(testOsoba);
            Assert.IsNotNull(resultOsoba);
            Assert.AreEqual(resultOsoba.Id, 1);
            Assert.AreEqual(testOsoba.Jmeno, resultOsoba.Jmeno);
            Assert.AreEqual(testOsoba.Kontakty.First().Hodnota, resultOsoba.Kontakty.First().Hodnota);
            Assert.AreEqual(testOsoba.Bydliste.Stat, resultOsoba.Bydliste.Stat);
        }

        [TestMethod]
        public void CreateOsobaRequiredTest()
        {
            ServiceManager serviceManager = new ServiceManager($"UnitTest_{Guid.NewGuid()}.db");

            var osoba = testOsoba;
            osoba.Jmeno = null!;

            try
            {
                OsobaDTO resultOsoba = serviceManager.CreateOsoba(osoba);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

        [TestMethod]
        public void GetOsobaTest()
        {
            ServiceManager serviceManager = new ServiceManager($"UnitTest_{Guid.NewGuid()}.db");

            serviceManager.CreateOsoba(testOsoba);

            OsobaDTO resultOsoba = serviceManager.GetOsoba(1);

            Assert.IsNotNull(resultOsoba);
            Assert.AreEqual(resultOsoba.Id, 1);
            Assert.AreEqual(testOsoba.Jmeno, resultOsoba.Jmeno);
            Assert.AreEqual(testOsoba.Kontakty.First().Hodnota, resultOsoba.Kontakty.First().Hodnota);
            Assert.AreEqual(testOsoba.Bydliste.Stat, resultOsoba.Bydliste.Stat);
        }

        [TestMethod]
        public void GetOsobaNotFoundTest()
        {
            ServiceManager serviceManager = new ServiceManager($"UnitTest_{Guid.NewGuid()}.db");

            try
            {
                OsobaDTO resultOsoba = serviceManager.GetOsoba(100);
                Assert.Fail();
            }
            catch (EntityNotFoundException)
            {
            }
        }

    }
}
