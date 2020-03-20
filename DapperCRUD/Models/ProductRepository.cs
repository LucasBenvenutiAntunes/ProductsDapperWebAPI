using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Models
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBProductDAPPER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var date = DateTime.Now;
                string datestring = date.ToShortDateString();

                string sQuery = @$"INSERT INTO Products (Name,Price,Created) VALUES(@Name, @Price, '{datestring}')";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (IDbConnection dbConnection = Connection)
            {
                //Sem Paginação:
                string sQuery = @"SELECT * FROM Products ORDER BY ProductId DESC";
                
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }


        public IEnumerable<Product> GetAllProductsByPage(int PageId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                //Com Paginação:
                string sQuery = @$"DECLARE @PageNumber int = { PageId }, " +
                                                "@RowsPerPage int= 4;  " +
                                                "SELECT * FROM Products ORDER BY ProductId DESC " +
                                                "OFFSET (@PageNumber) * @RowsPerPage ROWS " +
                                                "FETCH NEXT @RowsPerPage ROWS ONLY ";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { PageId });
            }
        }

        public Product GetProductsById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void DeleteProduct(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name, Price=@Price WHERE ProductId=@ProductId";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
