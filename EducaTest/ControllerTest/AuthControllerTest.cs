using Educa.Controllers;
using Educa.Models;
using Educa.Repository;
using Educa.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaTest.ControllerTest
{
    internal class AuthControllerTest
    {
        [Test]
        public void loginFalla()
        {

            var usuario = new Mock<IUsuarioRepository>();
            var cook = new Mock<ICookieAuthService> { CallBase = true };

            usuario.Setup(o => o.EncontrarUsuario("ermelindaF", null)).Returns(new Educa.Models.Usuario { NombreUsuario = "ermelindaF", Password = null });
            var controller = new AuthController(usuario.Object, cook.Object, null, null);

            var view = controller.Login("ermelindaF", null);
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void ingresarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Id = 5,
                NombreUsuario = "yasmin",
                Age = 6,
                Escuela = "san ramon",
                User = "yamisH",
                Password = "yasmin1",
                NombreTutor = "milton",
                EmailTutor = "milton_h@gmail.com",
                CelularTutor = "960998211",
                Avatar = "/Images/Home/Avatar6.png"
            };

            var user = new Mock<IUsuarioRepository>();
            var cook = new Mock<ICookieAuthService> { CallBase = true };

            user.Setup(o => o.AgregarUsuario(usuario));

            var controller = new AuthController(user.Object, cook.Object, null, null);
            var view = controller.SignIn(usuario);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void loginIngreso()
        {
            var usuario = new Mock<IUsuarioRepository>();
            var cook = new Mock<ICookieAuthService> { CallBase = true };

            usuario.Setup(o => o.EncontrarUsuario("Anita", "Anita.123")).Returns(new Usuario { });
            var controller = new AuthController(usuario.Object, cook.Object, null, null);

            var view = controller.Login("Anita", "Anita.123");
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }


    }
}
