﻿using Senai_Tarde.Domains;
using Senai_Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DESKTOP-16CG1FL\\SQLEXPRESS; initial catalog=Filmes_Prog; user Id=sa; pwd=sa@132;";

        public void Cadastrar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string insert = $"INSERT INTO Generos(Nome) VALUES ('{genero.Nome}') ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(insert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                    string query = "SELECT IdGenero, Nome FROM Generos";

                    con.Open();

                    SqlDataReader rdr;
                


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
    }
}
