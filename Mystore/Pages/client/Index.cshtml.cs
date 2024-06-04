using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mystore.Pages
{
    public class Index : PageModel
    {
        private readonly List<ClientInfo> _listClients = new List<ClientInfo>();

        public async Task OnGetAsync()
        {
            try
            {
                string connectionString = "Data Source=.\\Anjom;Initial Catalog=Mystore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM client";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var clientInfo = new ClientInfo
                                {
                                    Id = reader.GetInt32(0).ToString(),
                                    Name = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Phone = reader.GetString(3),
                                    Address = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5).ToString()
                                };

                                _listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك إضافة معالجة للأخطاء هنا
            }
        }

        public IEnumerable<ClientInfo> ListClients
        {
            get { return _listClients; }
        }
    }

    public class ClientInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CreatedAt { get; set; }
    }
}
