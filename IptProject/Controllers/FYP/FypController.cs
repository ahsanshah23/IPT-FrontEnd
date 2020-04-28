using IptProject.Models.FYP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers
{
    public class FypController : Controller
    {
        // GET: Cafeteria
        [HttpGet]
        public ActionResult GetProduct()
        {
            List<FoodItem> lstFoodItems = new List<FoodItem>();
            //FoodItem obj1 = new FoodItem(1, "Tikka", "avc", "Available", 200);
            //FoodItem obj2 = new FoodItem(2, "Pizza", "avc", "Available", 100);
            //lstFoodItems.Add(obj1);
            //lstFoodItems.Add(obj2);


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("cafeteria/getproduct");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FoodItem[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        lstFoodItems.Add(item);
                    }
                }
            }
            
            return View(lstFoodItems);
        }

        public ActionResult StudentProposal()
        {
            return View();
        }

        public ActionResult StudentHome()
        {
            return View();
        }

        public ActionResult TeacherHome()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> StudentProposal(StudentProposal student)
        {
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:44380/api/fyp1post/AddProposalStudent");

                var uri = "http://localhost:44380/api/fyp1post/AddProposalStudent";

                //HTTP POST
                var postTask = await client.PostAsJsonAsync(uri, student);
                //postTask.Wait();

                //var result = postTask.Result;
                //if (result.IsSuccessStatusCode)
                //{   
                    return RedirectToAction("GetProduct");
                //}
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
        }


        //// FYP 1 Forms Front /////
       

        public ActionResult DefenseForm()
        {
            return View();
        }
        public ActionResult Proposal()
        {
            return View();
        }
        public ActionResult SupervisorProposal()
        {
            return View();
        }
        public ActionResult Evaluation()
        {
            return View();
        }

        //// FYP 2 Forms Front /////


        public ActionResult FYP2MidEvaluation()
        {
            return View();
        }
        public ActionResult InternalJuryEvaluation()
        {
            return View();
        }
        public ActionResult ExternalJuryEvaluation()
        {
            return View();
        }

    }
}