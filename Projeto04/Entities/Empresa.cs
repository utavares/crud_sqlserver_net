using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Entities
{
    public class Empresa
    {
        #region Atributos

        private Guid _idEmpresa;
        private string? _nomeFantasia;
        private string? _razaoSocial;
        private string? _cnpj;
        private List<Funcionario>? _funcionarios;

        #endregion

        #region Construtores

        public Empresa()
        {
            
        }

        #endregion

        #region Propriedades

        public Guid IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public string? NomeFantasia { get => _nomeFantasia; set => _nomeFantasia = value; }
        public string? RazaoSocial { get => _razaoSocial; set => _razaoSocial = value; }
        public string? Cnpj { get => _cnpj; set => _cnpj = value; }
        public List<Funcionario>? Funcionarios { get => _funcionarios; set => _funcionarios = value; }


        #endregion
    }
}
