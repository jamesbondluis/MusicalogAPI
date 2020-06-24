using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class AlbumDAL
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public IEnumerable<AlbumDTO> Get()
        {
            string sql = "select * from Album";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataReader reader;
            connection.Open();

            var albums = new List<AlbumDTO>();

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    albums.Add(new AlbumDTO
                    {
                        AlbumID = Convert.ToInt32(reader[0]),
                        AlbumName = reader[1].ToString(),
                        ArtistName = reader[2].ToString(),
                        Type = reader[3].ToString(),
                        Stock = Convert.ToInt32(reader[4])
                    });
                }
            }
            finally
            {
                connection.Close();
            }

            return albums;
        }

        public AlbumDTO Get(int id)
        {
            string sql = "select * from Album where AlbumID = " + id;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataReader reader;
            connection.Open();

            var album = new AlbumDTO();

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    album = new AlbumDTO
                    {
                        AlbumID = Convert.ToInt32(reader[0]),
                        AlbumName = reader[1].ToString(),
                        ArtistName = reader[2].ToString(),
                        Type = reader[3].ToString(),
                        Stock = Convert.ToInt32(reader[4])
                    };
                }
            }
            finally
            {
                connection.Close();
            }

            return album;
        }
        public void Post(AlbumDTO album)
        {
            var sql = "insert into Album values (@albumName, @artistName, @type, @stock)";

            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@albumName", album.AlbumName);
            command.Parameters.AddWithValue("@artistName", album.ArtistName);
            command.Parameters.AddWithValue("@type", album.Type);
            command.Parameters.AddWithValue("@stock", album.Stock);
            command.CommandType = System.Data.CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Put(int id, AlbumDTO album)
        {
            var sql = "update Album set AlbumName = @albumName, ArtistName = @artistName, Type = @type, Stock = @stock where AlbumID = @albumId";

            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@albumId", id);
            command.Parameters.AddWithValue("@albumName", album.AlbumName);
            command.Parameters.AddWithValue("@artistName", album.ArtistName);
            command.Parameters.AddWithValue("@type", album.Type);
            command.Parameters.AddWithValue("@stock", album.Stock);
            command.CommandType = System.Data.CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var sql = "delete from Album where AlbumID = @albumId";

            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@albumId", id);
            command.CommandType = System.Data.CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
