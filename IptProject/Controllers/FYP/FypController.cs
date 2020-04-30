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


        
        //// FYP 1 Forms Front /////
        

        [HttpPost]
        public ActionResult StudentProposal(StudentProposal student)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/fyp1post/addproposalstudent");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentProposal>("addproposalstudent", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("StudentHome");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewStudentProposal()
        {
            List<StudentProposal> StudentProposalItems = new List<StudentProposal>();
           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetProposalDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentProposal[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        StudentProposalItems.Add(item);
                    }
                }
            }

            return View(StudentProposalItems);
        }

        [HttpGet]
        public ActionResult SupervisorProposalCards()
        {

            List<StudentProposal> lstFoodItems = new List<StudentProposal>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetProposalsNameSupervisor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentProposal[]>();
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

        public ActionResult ViewStudentProposalSupervisor()
        {
            
            return View();
        }

        public ActionResult DefenseForm()
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