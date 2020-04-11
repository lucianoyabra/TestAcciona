using NUnit.Framework;
using TestAccionaIT;

namespace TestUnitario
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogin()
        {
            Login log = new Login();
            string respuestaLogin = log.LoguearUsuer("user", "123");
            string respuestaLoginEsperada = "{" + '"' + "user" + '"' + ":" + '"' + "user" + '"' +"," + '"' + "password" + '"' + ":" + '"' + "123" + '"' + "," + '"' + "email" + '"' + ":" + '"' + "usuarioaccionatest@gmail.com" + '"' + "," + '"' + "nombre" + '"' + ":" + '"' + "Usuario" + '"' + "," + '"' + "apellido" + '"' + ":" + '"' + "Acciona" + '"' +"}";
            
            Assert.AreEqual(respuestaLoginEsperada,respuestaLogin);
            
        }
        
        [Test]
        public void TestProvincia()
        {
            Provincias prov = new Provincias();
            string respuestaProvincia = prov.GetLatLongProvincia("Chaco");
            string respuestaProvinciaEsperada = "La provincia Chaco tiene de lon: -60.7658307438603 y tiene de lat: -26.3864309061226";
        }

    }
}