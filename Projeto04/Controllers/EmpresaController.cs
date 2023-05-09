using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class EmpresaController
    {
        //atributo
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE EMPRESA\n");

                var empresa = new Empresa();

                Console.WriteLine("ENTRE COM O NOME FANTASIA");
                empresa.NomeFantasia = Console.ReadLine();

                Console.WriteLine("ENTRE COM A RAZÃO SOCIAL");
                empresa.RazaoSocial = Console.ReadLine();

                Console.WriteLine("ENTRE COM O CNPJ");
                empresa.Cnpj = Console.ReadLine();

                _empresaRepository.Add(empresa);

                Console.WriteLine("EMPRESA CADASTRADA COM SUCESSO!");

            }
            catch (Exception e) 
            {
                Console.WriteLine($"\nFALHA AO CADASTRAR EMPRESA: {e.Message}");
            }
        }

        public void AtualizarEmpresa()
        {
            try
            {
                Console.WriteLine("ENTRE COM ID DA EMPRESA");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                var empresa = _empresaRepository.GetById(idEmpresa);

                if (empresa != null)
                {
                    Console.WriteLine("\nDADOS DA EMPRESA");
                    Console.WriteLine($"\tID DA EMPRESA.......: {empresa.IdEmpresa}");
                    Console.WriteLine($"\tNOME FANTASIA.......: {empresa.NomeFantasia}");
                    Console.WriteLine($"\tRAZAO SOCIAL........: {empresa.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ................: {empresa.Cnpj}");

                    Console.WriteLine("\nENTRE COM O NOME FANTASIA");
                    empresa.NomeFantasia = Console.ReadLine();

                    Console.WriteLine("\nENTRE COM A RAZÃO SOCIAL");
                    empresa.RazaoSocial = Console.ReadLine();

                    Console.WriteLine("\nENTRE COM O CNPJ");
                    empresa.Cnpj = Console.ReadLine();

                    _empresaRepository.Update(empresa);

                    Console.Write("EMPRESA ATUALIZADA COM SUCESSO!");

                }
                else
                {
                    Console.WriteLine("\nEMPRESA NÃO ENCONTRADA.");
                }

            }

            catch(Exception e) 
            {

                Console.WriteLine("\nFALHA AO ATUALIZAR EMPRESA: " + e.Message);

            }
        }

        public void ExcluirEmpresa()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE EMPRESA:\n");

                Console.WriteLine("ENTRE COM ID DA EMPRESA");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                var empresa = _empresaRepository.GetById(idEmpresa);

                if (empresa != null)
                {
                    Console.WriteLine("\nDADOS DA EMPRESA");
                    Console.WriteLine($"\tID DA EMPRESA.......: {empresa.IdEmpresa}");
                    Console.WriteLine($"\tNOME FANTASIA.......: {empresa.NomeFantasia}");
                    Console.WriteLine($"\tRAZAO SOCIAL........: {empresa.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ................: {empresa.Cnpj}");

                    Console.WriteLine("\nDESEJA EXCLUIR A EMPRESA? (S,N):");
                    var opcao = Console.ReadLine();

                    if (opcao.Equals("S",StringComparison.OrdinalIgnoreCase))
                    {
                        _empresaRepository.Delete(empresa);

                        Console.Write("\nEMPRESA EXCLUÍDA COM SUCESSO!");
                    }
                    else
                    {
                        Console.Write("\nOPERAÇÃO CANCELADA.");
                    }
                }
                else
                {
                    Console.WriteLine("\nEMPRESA NÃO ENCONTRADA.");
                }

            }

            catch (Exception e)
            {

                Console.WriteLine("\nFALHA AO EXCLUIR EMPRESA: " + e.Message);

            }
        }

        public void ConsultarEmpresas()
        {
            try
            {
                Console.WriteLine("\nCONSULTAR EMPRESAS:\n");

                var empresas = _empresaRepository.GetAll();

                foreach (var item in empresas)
                {
                    Console.WriteLine($"ID DA EMPRESA.......: {item.IdEmpresa}");
                    Console.WriteLine($"NOME FANTASIA.......: {item.NomeFantasia}");
                    Console.WriteLine($"RAZAO SOCIAL........: {item.RazaoSocial}");
                    Console.WriteLine($"CNPJ................: {item.Cnpj}");
                    Console.WriteLine("...");
                }

                Console.WriteLine($"\nQUANTIDADE DE EMPRESAS: {empresas.Count}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO CONSULTAR EMPRESAS: {e.Message}");
            }

        }
    }
}
