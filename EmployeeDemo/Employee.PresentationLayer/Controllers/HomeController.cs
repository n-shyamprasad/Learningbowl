using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Emp.ModelLayer;

namespace Emp.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = GetEmployee();
            return View(employees);
        }

        public ActionResult Get(int Id)
        {
            Employee employee = GetEmployeeById(Id);
            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            return View("Index", employees);
        }

        Employee GetEmployeeById(int Id)
        {
            Employee employee = null;
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:59505/api/employee?id=" + Id;
                Task<HttpResponseMessage> result = client.GetAsync(url);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serializedResult = result.Result.Content.ReadAsStringAsync();
                    employee = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(serializedResult.Result);
                }
            }
            return employee;
        }

        IEnumerable<Employee> GetEmployee()
        {
            IEnumerable<Employee> employees = null;
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:59505/api/employee";
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = client.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serializedResult = result.Result.Content.ReadAsStringAsync();
                    employees = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Employee>>(serializedResult.Result);
                }
            }
            return employees;
        }


            #region default methods commented
            /*
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
            */
            #endregion
        }
}