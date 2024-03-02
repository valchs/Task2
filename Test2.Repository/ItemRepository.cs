using System.Data;
using System.Data.SqlClient;
using Test2.Models;

namespace Test2.Repository
{
	public class ItemRepository : IItemRepository
	{
        private readonly string _connectionString = "your_connection_string";

        public bool Insert(ItemInsertModel item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[set_Items]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@nId", item.Id.HasValue ? (object)item.Id : DBNull.Value);
                        command.Parameters.AddWithValue("@itemName", item.ItemName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@unit", item.Unit ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@amount", item.Amount.HasValue ? (object)item.Amount : DBNull.Value);
                        command.Parameters.AddWithValue("@techSpecification", item.TechSpecification ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@categoryId", item.CategoryId.HasValue ? (object)item.CategoryId : DBNull.Value);

                        connection.Open();

                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
