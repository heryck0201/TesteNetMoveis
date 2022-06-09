using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteNetMoveis.Models;

namespace TesteNetMoveis.Controllers
{
    public class ImovelController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var returnRequest = client.GetAsync(" /api/v1/Imoveis").GetAwaiter().GetResult();

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                List<Imovel> baseResult = JsonConvert.DeserializeObject<List<Imovel>>(returnContent);

                return View(baseResult);
            }
            catch (Exception ex)
            {
                TempData["MensagemSucesso"] = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult CriarImovel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Imovel obj)
        {
            try
            {
                var serializerModelImovel = JsonConvert.SerializeObject(obj);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var stringContent = new StringContent(serializerModelImovel, Encoding.UTF8, "application/json");
                var returnRequest = client.PostAsync("/api/v1/Imoveis", stringContent).GetAwaiter().GetResult();

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Imovel baseResult = JsonConvert.DeserializeObject<Imovel>(returnContent);

                return Redirect("Index");
            }
            catch (Exception ex)
            {

                TempData["MensagemSucesso"] = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var returnRequest = client.GetAsync(" /api/v1/Imoveis/" + id).GetAwaiter().GetResult();

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Imovel baseResult = JsonConvert.DeserializeObject<Imovel>(returnContent, new JsonSerializerSettings() { Culture = System.Globalization.CultureInfo.CurrentCulture });

                return View(baseResult);
            }
            catch (Exception ex)
            {
                TempData["MensagemSucesso"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditarImovel(Imovel obj)
        {
            try
            {
                var serializerModelImovel = JsonConvert.SerializeObject(obj);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var stringContent = new StringContent(serializerModelImovel, Encoding.UTF8, "application/json");
                var returnRequest = client.PutAsync("/api/v1/Imoveis/" + obj.Id, stringContent).GetAwaiter().GetResult();

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return Redirect("Editar?id=" + obj.Id);
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return Redirect("Editar?id=" + obj.Id);
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Imovel baseResult = JsonConvert.DeserializeObject<Imovel>(returnContent);

                return Redirect("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemSucesso"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var returnRequest = client.GetAsync(" /api/v1/Imoveis/" + id).GetAwaiter().GetResult();

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Imovel baseResult = JsonConvert.DeserializeObject<Imovel>(returnContent, new JsonSerializerSettings() { Culture = System.Globalization.CultureInfo.CurrentCulture });

                return View(baseResult);
            }
            catch (Exception ex)
            {
                TempData["MensagemSucesso"] = ex.Message;
                return Redirect("Detalhe");
            }
        }
        [HttpGet]
        public IActionResult Apagar(int id)
        {
          
            return View(id);
        }

        [HttpGet]
        public IActionResult ApagarPost(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://62a0e2547b9345bcbe416e45.mockapi.io");

                var returnRequest = client.DeleteAsync(" /api/v1/Imoveis/" + id).GetAwaiter().GetResult();
                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                if (returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) ||
                    returnRequest.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    TempData["MensagemSucesso"] = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return View();
                }

                var returnContent = returnRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Imovel baseResult = JsonConvert.DeserializeObject<Imovel>(returnContent, new JsonSerializerSettings() { Culture = System.Globalization.CultureInfo.CurrentCulture });

                return View("Index");
            }
            catch (Exception ex)
            {

                TempData["MensagemSucesso"] = ex.Message;
                return Redirect("Apagar");
            }
            
        }


    }
}
