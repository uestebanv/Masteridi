using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmisorController : Controller
    {
        // GET: Emisor
        [HttpGet]
        /*
         public ActionResult Index()
         {
             ML.Emisor emisor = BL.Emisor.GetAll();
             var result = emisor.Emisores;
             return View(emisor);
         }
        */
       
        
        public ActionResult Index()
        {
            ML.Emisor emisor = new ML.Emisor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");
                var responseTask = client.GetAsync("Emisor/GetAll");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Emisor>();
                    readTask.Wait();
                    emisor = readTask.Result;
                }
            }
            return View(emisor);
        }
        /*
        public ActionResult Form(int? IdEmisor)
        {
            ML.Emisor emisor = new ML.Emisor();

            if (IdEmisor != null)
            {
                var result = BL.Emisor.GetById(IdEmisor.Value);
                if (result != null)
                {
                    //UNBOXING
                    emisor = (ML.Emisor)result;
                }

            }
            return View(emisor);
        }
        */
        [HttpGet]
        public ActionResult Form(int? IdEmisor)
        {
            ML.Emisor emisor = new ML.Emisor();
            if (IdEmisor != null)
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44337/api/");
                    var responseTask = cliente.GetAsync("Emisor/GetById/" + IdEmisor);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Emisor>();
                        readTask.Wait();
                        emisor = readTask.Result;
                    }

                }
            }
            return View(emisor);
        }
        [HttpPost]
        /*
        public ActionResult Form(ML.Emisor emisor)
        {
            if (ModelState.IsValid)
            {
                if (emisor.IdEmisor == 0)
                {
                    var result = BL.Emisor.Add(emisor);
                    if (result != null)
                    {
                        ViewBag.Mensaje = "Se ha ingresado correctamente el Emisor";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha ingresado correctamente el Emisor. Error: " + result;
                    }
                }
                else
                {
                    var result = BL.Emisor.Update(emisor);
                    if (result != null)
                    {
                        ViewBag.Mensaje = "se ha actualizado correctamente el Emisor";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar correctamente el Emisor. Error: " + result;
                    }
                }
            }
            else
            {
                return View(emisor);
            }
            return PartialView("Modal");
        }
        */
        public ActionResult Form(ML.Emisor emisor)
        {
            if (emisor.IdEmisor == 0) //ADD
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44337/api/");

                    var postTask = cliente.PostAsJsonAsync("Emisor/Add", emisor);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        emisor.IdEmisor = result.Content.ReadAsAsync<int>().Result;
                        ViewBag.Mensaje = "Se agrego correctamente el Emisor y su Id Asignado es: " + emisor.IdEmisor;
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo agregar el Emisor";
                    }
                }
            }
            else //UPDATE
            {
                using (var cliente = new HttpClient())
                {
                    int IdEmisor = emisor.IdEmisor;

                    cliente.BaseAddress = new Uri("https://localhost:44337/api/");

                    var putTask = cliente.PutAsJsonAsync("Emisor/Update/" + IdEmisor, emisor);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se actualizo correctamente el Emisor";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se logro actualizar el Emisor";
                    }
                }
            }
            return PartialView("Modal");
        }
        /*
        public ActionResult Delete(int? IdEmisor)
        {
            bool result = BL.Emisor.Delete(IdEmisor.Value);
            if (result)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el registro";
            }
            else
            {
                ViewBag.Mensaje = "NO se ha eliminado correctamente el registro. Error: " + result;
            }
            return PartialView("Modal");
        }
        */
        public ActionResult Delete(int IdEmisor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44337/api/");

                var deleteTask = client.DeleteAsync("Emisor/Delete/" + IdEmisor);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Error");
        }
    }
}