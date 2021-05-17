using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SLB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SLB.Data
{
    public class QueryByCustomerCatName
    {
        private IConfiguration configuration;
        private WideWorldImportersContext db = new WideWorldImportersContext();
        string str = "Server=(LocalDb)\\LocalSLBDB;Database=WideWorldImporters;Trusted_Connection=True;";
        public List<Customer> SelectDataByCustomerCatName(string customer)
        {
            try
            {
                List<Customer> project = new List<Customer>();
                SqlConnection conn = new SqlConnection(str);
                {
                    conn.Open();
                    if (customer.ToLower() == "all")
                    {
                        project = (from proj in db.Customers
                                   select new Customer
                                   {
                                       CustomerName = proj.CustomerName,
                                       PrimaryContact = proj.PrimaryContact,
                                       PhoneNumber = proj.PhoneNumber,
                                       CityName = proj.CityName,
                                       CustomerCategoryName = proj.CustomerCategoryName
                                   }).ToList();
                    }
                    else
                    {
                        project = (from proj in db.Customers
                                   where proj.CustomerCategoryName == customer
                                   select new Customer
                                   {
                                       CustomerName = proj.CustomerName,
                                       PrimaryContact = proj.PrimaryContact,
                                       PhoneNumber = proj.PhoneNumber,
                                       CityName = proj.CityName,
                                       CustomerCategoryName = proj.CustomerCategoryName
                                   }).ToList();
                    }
                    conn.Close();
                }

                return project;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("ERROR: ", Convert.ToString(ex.Message));
            }
        }
    }
}
