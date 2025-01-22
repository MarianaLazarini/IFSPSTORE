using AutoMapper;
using IFSPStory.Domain.Base;
using IFSPStory.Domain.Entities;
using IFSPStory.Repository.Context;
using IFSPStory.Repository.Repository;
using IFSPStory.Service.Service.IFSPStore.Service.Services;
using IFSPStory.Service.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;


namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestService
    {
        private ServiceCollection? services;

        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<MySqlContext>(options =>
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "**********";
                var strCon = $"Server={server}; Port={port}; Database={database};" +
                             $"Uid={username}; Pwd={password}";
                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, Usuario>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            services.AddScoped<IBaseService<Cidade>, BaseService<Cidade>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cidade, Cidade>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Grupo>, BaseRepository<Grupo>>();
            services.AddScoped<IBaseService<Grupo>, BaseService<Grupo>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Grupo, Grupo>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Produto, Produto>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddScoped<IBaseService<Cliente>, BaseService<Cliente>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, Cliente>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();
            services.AddScoped<IBaseService<Venda>, BaseService<Venda>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Venda, Venda>();
            }).CreateMapper());

            return services.BuildServiceProvider();
        }

        [TestMethod]
        public void TestInsertCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();
            var cidade = new Cidade()
            {
                Nome = "Birigui",
                Estado = "SP"
            };

            var result = cidadeService.Add<Cidade, Cidade, CidadeValidator>(cidade);
            Console.Write(JsonSerializer.Serialize(result));
        }

        public void TestInsertCliente()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();
            var cidade = cidadeService.Get<Cidade>().FirstOrDefault(c => c.Id >= 1);
            var clienteService = sp.GetService<IBaseService<Cliente>>();
            var cliente = new Cliente()
            {
                Nome = "Mariana",
                Endereco = "Rua Islândia",
                Bairro = "Jardim São Paulo",
                Documento = "***.***.***-**",
                Cidade = cidade
            };

            var result = clienteService.Add<Cliente, Cliente, ClienteValidator>(cliente);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();
            var grupo = new Grupo()
            {
                Nome = "Grupo 1"
            };

            var result = grupoService.Add<Grupo, Grupo, GrupoValidator>(grupo);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertProduto()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();
            var grupo = grupoService.Get<Grupo>().FirstOrDefault(c => c.Id >= 1);
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var produto = new Produto()
            {
                Id = 1,
                Nome = "Geladeira",
                Preco = 3000.00f,
                Quantidade = 3,
                DataCompra = DateTime.Now,
                UnidadeVenda = "Unidade",
                Grupo = grupo
            };

            var result = produtoService.Add<Produto, Produto, ProdutoValidator>(produto);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();
            var usuario = new Usuario()
            {
                Nome = "Mariana",
                Login = "Mari",
                Email = "marisolazarini@gmail.com",
                Senha = "**********",
                DataCadastro = DateTime.Now,
                DataLogin = DateTime.Now,
                Ativo = false
            };

            var result = usuarioService.Add<Usuario, Usuario, UsuarioValidator>(usuario);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertVenda()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();
            var usuario = usuarioService.Get<Usuario>().FirstOrDefault(c => c.Id >= 1);
            var clienteService = sp.GetService<IBaseService<Cliente>>();
            var cliente = clienteService.Get<Cliente>().FirstOrDefault(d => d.Id >= 1);
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var produto = produtoService.Get<Produto>().FirstOrDefault(e => e.Id >= 1);
            var vendaService = sp.GetService<IBaseService<Venda>>();
            var venda = new Venda()
            {
                Data = DateTime.Now,
                ValorTotal = 10000.00f,
                Usuario = usuario,
                Cliente = cliente,
                //Itens = itens
            };

            venda.Items.Add(
            new VendaItem
            {
                Produto = produto,
                Quantidade = 2,
                ValorUnitario = 3000.00f,
                ValorTotal = 6000.00f,
                Venda = venda
            });

            var result = vendaService.Add<Venda, Venda, VendaValidator>(venda);
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectCidade()
        {
            var sp = ConfigureServices();
            var CidadeServices = sp.GetService<IBaseService<Cidade>>();
            var result = CidadeServices.Get<Cidade>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectCliente()
        {
            var sp = ConfigureServices();
            var ClienteServices = sp.GetService<IBaseService<Cliente>>();
            var result = ClienteServices.Get<Cliente>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectGrupo()
        {
            var sp = ConfigureServices();
            var GrupoServices = sp.GetService<IBaseService<Grupo>>();
            var result = GrupoServices.Get<Grupo>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectProduto()
        {
            var sp = ConfigureServices();
            var ProdutoServices = sp.GetService<IBaseService<Produto>>();
            var result = ProdutoServices.Get<Produto>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            var sp = ConfigureServices();
            var UsuarioServices = sp.GetService<IBaseService<Usuario>>();
            var result = UsuarioServices.Get<Usuario>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectVenda()
        {
            var sp = ConfigureServices();
            var VendaServices = sp.GetService<IBaseService<Venda>>();
            var result = VendaServices.Get<Venda>();
            Console.Write(JsonSerializer.Serialize(result));
        }
    }
}
