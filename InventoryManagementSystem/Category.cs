﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Category
    {
        public string id;
        public string name;

        public Category(string id, string name)
        {
            this.id = id;
            this.name = name;
            
        }

        // Create
        public static int AddCategory(string name)
        {
            try
            {
                // Opening a connection to MySql server
                string connectionString = "server=localhost;database=inventory;uid=root;pwd=prince;";
                MySqlConnection conn = new MySqlConnection(connectionString);

                conn.Open();


                // SQL Query to insert new user
                string sqlquery = $"INSERT INTO `category` (`name`) VALUES (?name);";
                MySqlCommand cmd = new MySqlCommand(sqlquery, conn);
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                
                cmd.ExecuteNonQuery();
                conn.Close();
                //MySqlDataReader rdr = cmd.ExecuteReader();
                //rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

            return 1;
        }

        // Read
        public static List<Category> GetCategories()
        {
            // list of Category Objects
            List<Category> categories = new List<Category>();
            try
            {
                // Opening a connection to MySql server
                string connectionString = "server=localhost;database=inventory;uid=root;pwd=prince;";
                MySqlConnection conn = new MySqlConnection(connectionString);

                conn.Open();


                // SQL Query to insert new category
                string sqlquery = "SELECT * FROM category;";
                MySqlCommand cmd = new MySqlCommand(sqlquery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categories.Add(new Category(rdr[0].ToString(), rdr[1].ToString()));
                }
                rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return categories;
            }

            return categories;
        }

        // Update
        public static int UpdateCategory(int id, string name)
        {
            try
            {
                // Opening a connection to MySql server
                string connectionString = "server=localhost;database=inventory;uid=root;pwd=prince;";
                MySqlConnection conn = new MySqlConnection(connectionString);

                conn.Open();


                // SQL Query to update user where id=id
                string sqlquery = "UPDATE `category` SET `name` = ?name WHERE (`id` = ?id);";

                MySqlCommand cmd = new MySqlCommand(sqlquery, conn);
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("?id", MySqlDbType.Int64).Value = id;
                cmd.ExecuteNonQuery();
                conn.Close();
                //MySqlDataReader rdr = cmd.ExecuteReader();
                //rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

            return 1;
        }

        // Delete
        public static int DeleteCategory(string name)
        {
            try
            {
                // Opening a connection to MySql server
                string connectionString = "server=localhost;database=inventory;uid=root;pwd=prince;";
                MySqlConnection conn = new MySqlConnection(connectionString);

                conn.Open();


                // SQL Query to insert new user
                string sqlquery = $"DELETE FROM `category` WHERE (`name` = ?name);";
                MySqlCommand cmd = new MySqlCommand(sqlquery, conn);
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

            return 1;
        }
    }
}