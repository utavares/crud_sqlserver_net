using Dapper;
using Projeto04.Entities;
using Projeto04.Helpers;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string? _connectionString;

        public FuncionarioRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString();
        }

        public void Add(Funcionario funcionario)
        {
            var query = @"
                INSERT INTO EMPRESA(IDFUNCIONARIO, NOME, CPF, MATRICULA, DATADEADMISSAO) 
                VALUES (NEWID(), @Nome, @Cpf, @Matricula, @DataDeAdmissao)
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Delete(Funcionario funcionario)
        {
            var query = @"
                DELETE FROM FUNCIONARIO WHERE IDFUNCIONARIO = @IdFuncionario
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public List<Funcionario> GetAll()
        {
            var query = @"
                SELECT 
                    IDFUNCIONARIO AS IdFuncionario, 
                    NOME AS Nome, 
                    CPF AS Cpf, 
                    MATRICULA AS Matricula,
                    DATADEADMISSAO AS DataDeAdmissao
                FROM EMPRESA 
                ORDER BY NOMEFANTASIA
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario? GetById(Guid idFuncionario)
        {
            var query = @"
                SELECT 
                    IDFUNCIONARIO AS IdFuncionario, 
                    NOME AS Nome, 
                    CPF AS Cpf, 
                    MATRICULA AS Matricula,
                    DATADEADMISSAO AS DataDeAdmissao
                FROM EMPRESA
                WHERE IDFUNCIONARIO = @idFuncionario
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(query, new { idFuncionario }).FirstOrDefault();
            }
        }

        public void Update(Funcionario funcionario)
        {
            var query = @"
                UPDATE FUNCIONARIO SET
                    NOME = @Nome, 
                    CPF = @Cpf,
                    MATRICULA = @Matricula,
                    DATADEASMISSAO = @DataDeAdmissao
                WHERE IDFUNCIONARIO = @IdFuncionario
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }
    }
}
