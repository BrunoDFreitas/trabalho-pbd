using SistemaGerencia.BaseModel.ConcreteRepository;
using SistemaGerencia.BaseModel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Unit
{
    public class UnitOfWork : IDisposable
    {
        
        private DbContext context;
        public DbContext Context
        {
            get
            {
                return context;
            }
        }


        public UnitOfWork()
        {
            string conn = "name=MySQLConn";

            context = new MySQLContext(conn);

            context.Configuration.AutoDetectChangesEnabled = false;

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(context);
        }


        private PessoaRepository pessoaRepository;
        public PessoaRepository Pessoa
        {
            get
            {
                if(pessoaRepository == null)
                {
                    pessoaRepository = new PessoaRepository(this);
                }
                return pessoaRepository;
            }
        }

        private EnderecoRepository enderecoRepository;
        public EnderecoRepository Endereco
        {
            get
            {
                if (enderecoRepository == null)
                {
                    enderecoRepository = new EnderecoRepository(this);
                }
                return enderecoRepository;
            }
        }

        private ClienteRepository clienteRepository;
        public ClienteRepository Cliente
        {
            get
            {
                if (clienteRepository == null)
                {
                    clienteRepository = new ClienteRepository(this);
                }
                return clienteRepository;
            }
        }

        private FornecedorRepository fornecedorRepository;
        public FornecedorRepository Fornecedor
        {
            get
            {
                if (fornecedorRepository == null)
                {
                    fornecedorRepository = new FornecedorRepository(this);
                }
                return fornecedorRepository;
            }
        }

        
        private PrestadorServicoRepository prestadorServicoRepository;
        public PrestadorServicoRepository PrestadorServico
        {
            get
            {
                if (prestadorServicoRepository == null)
                {
                    prestadorServicoRepository = new PrestadorServicoRepository(this);
                }
                return prestadorServicoRepository;
            }
        }

        
        private ServidorTerceirizadoRepository servidorTerceirizadoRepository;
        public ServidorTerceirizadoRepository ServidorTerceirizado
        {
            get
            {
                if (servidorTerceirizadoRepository == null)
                {
                    servidorTerceirizadoRepository = new ServidorTerceirizadoRepository(this);
                }
                return servidorTerceirizadoRepository;
            }
        }


        private ColaboradorRepository colaboradorRepository;
        public ColaboradorRepository Colaborador
        {
            get
            {
                if (colaboradorRepository == null)
                {
                    colaboradorRepository = new ColaboradorRepository(this);
                }
                return colaboradorRepository;
            }
        }


        private SocioRepository socioRepository;
        public SocioRepository Socio
        {
            get
            {
                if (socioRepository == null)
                {
                    socioRepository = new SocioRepository(this);
                }
                return socioRepository;
            }
        }


        private FuncionarioRepository funcionarioRepository;
        public FuncionarioRepository Funcionario
        {
            get
            {
                if (funcionarioRepository == null)
                {
                    funcionarioRepository = new FuncionarioRepository(this);
                }
                return funcionarioRepository;
            }
        }

        
        private SolicitacaoOrcamentoRepository solicitacaoOrcamentoRepository;
        public SolicitacaoOrcamentoRepository SolicitacaoOrcamento
        {
            get
            {
                if (solicitacaoOrcamentoRepository == null)
                {
                    solicitacaoOrcamentoRepository = new SolicitacaoOrcamentoRepository(this);
                }
                return solicitacaoOrcamentoRepository;
            }
        }

        
        private OrcamentoRespository orcamentoRespository;
        public OrcamentoRespository Orcamento
        {
            get
            {
                if (orcamentoRespository == null)
                {
                    orcamentoRespository = new OrcamentoRespository(this);
                }
                return orcamentoRespository;
            }
        }

        
        private ServicoRespository servicoRespository;
        public ServicoRespository Servico
        {
            get
            {
                if (servicoRespository == null)
                {
                    servicoRespository = new ServicoRespository(this);
                }
                return servicoRespository;
            }
        }
    }
}
