using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

/*
 Instrucciones:
Resolver la mayor cantidad de ejercicios listados a continuación.
No permitido el uso de scaffolding
Al finalizar, se deberá entregar la solución completa (preferentemente en ZIP/RAR) que incluya los ejercicios resueltos.
Target Frameworks recomendados: NET FRAMEWORK 4.5 o posterior / NET CORE 3.1 o posterior.
Lista de problemas:
Crear un servicio web (REST o SOAP) utilizando frameworks .NET (ASP .NET WEB SERVICES 2.0, WCF, ASP .NET WEB API, ASP .NET CORE MVC) que exponga las siguientes operaciones:
Permita recibir la entidad “Emisor” y la guarde en base de datos (tabla Emisores) (usar Entity Framework 6.x ó Entity Framework Core >= 3.x para acceso a datos) y regrese el Id del “Emisor”.
Permita listar las entidades “Emisor” almacenadas en base de datos.
Entidad emisor:
public class Emisor
{
Public string Id {get;set;}
public string Rfc { get; set; }
public DateTime FechaInicioOperacion { get; set; }
public decimal Capital { get; set; }
 }

Crear una aplicación cliente con GUI (ASP .NET MVC, ASP .NET Core (MVC / Razor Pages), Consola, Windows Forms, WPF)  que sea cliente de la API del punto #1 y que tenga las siguientes funcionalidades:
Que solicite los datos del emisor y permita registrar el emisor mediante un botón y muestre un mensaje con el estatus de la solicitud.
Que muestre el listado de los emisores registrados.
 

(Ejercicio para punto extra) Un número palíndromo se lee de la misma forma IZQ-DER, DER-IZQ. Escribir una función que, encuentre el palíndromo más grande formado por el producto de 2 números de 3 dígitos.
Ejemplo:

El número palíndromo más grande del producto de 2 números de 2 dígitos es 9009 = 91 x 99.
 */