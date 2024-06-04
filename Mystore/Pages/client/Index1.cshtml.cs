using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mystore.Pages.client
{
    public class Index1Model : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";

        public string successMessage { get; private set; }

        public void OnGet()
        {
        }
        public void OnPost() 
        {
            clientInfo.Name = Request.Form["name"];
            clientInfo.Address = Request.Form["address"];
            clientInfo.Email = Request.Form["email"];
            clientInfo.Phone = Request.Form["phone"];
            clientInfo = new ClientInfo();
            if(clientInfo.Name.Length == 0 ||clientInfo.Email.Length == 0 || clientInfo.Phone.Length == 0 || clientInfo.Address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            //save the new client into the database
            clientInfo.Name = ""; clientInfo.Email = ""; clientInfo.Phone = ""; clientInfo.Address = "";
            successMessage = "New client Added Correctly";
        }
    }
}
