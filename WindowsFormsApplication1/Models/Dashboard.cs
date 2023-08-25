using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.DataBase.Models
{

    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }

    }

    public class Dashboard : Db_Connection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public int NumOrders { get; set; }
        public List<KeyValuePair<string, int>> TopProductList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }


        // Methods

        public Dashboard()
        {


        }

        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    
                    command.CommandText = "Select count(id) from Customer";
                    NumCustomers = (int)command.ExecuteScalar();

                    command.CommandText = "Select count(id) from Supplier ";
                    NumSuppliers = (int)command.ExecuteScalar();

                    command.CommandText = "Select count(id) from Product";
                    NumProducts = (int)command.ExecuteScalar();

                    command.CommandText = "Select count(id) from Order" +
                        "where OrderDate between @fromDate and @toDate";

                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
        }
    }



}
