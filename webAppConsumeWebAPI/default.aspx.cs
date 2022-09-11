using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppConsumeWebAPI
    {
    public partial class _default : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            }

        protected void btnGet_Click(object sender, EventArgs e)
            {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization",
                        Convert.ToBase64String(Encoding.Default.GetBytes("AdminUser:123456")));
            //Need to change the PORT number where your WEB API service is running
            var result = client.GetAsync(new Uri("https://localhost:44341/api/employees")).Result;
            StringBuilder sb = new StringBuilder();
            if (result.IsSuccessStatusCode)
                {
                sb.AppendLine("Done" + result.StatusCode);
                var JsonContent = result.Content.ReadAsStringAsync().Result;
                List<Employee> empList = JsonConvert.DeserializeObject<List<Employee>>(JsonContent);
                foreach (var emp in empList)
                    {
                    sb.AppendLine("Name = " + emp.Name + " Gender = " + emp.Gender + " Dept = " + emp.Dept + " Salary = " + emp.Salary);
                    }
                }
            else
                {
                sb.AppendLine("Error" + result.StatusCode);
                }
            lblMsg.Text = sb.ToString();

            }

        }
    public class Employee
        {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Dept { get; set; }
        public int Salary { get; set; }
        }
    }