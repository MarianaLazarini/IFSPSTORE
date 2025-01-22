using IFSPStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static IFSPStory.Teste.UnitTestRepository;

namespace IFSPStory.Teste
{
    [TestClass]

    public class UnitTestRepository()
    {
        public partial class MyDbContext : DbContext
        {
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Cidade> Cidade { get; set; }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<Grupo> Grupo { get; set; }
            public DbSet<Produto> Produto { get; set; }
            public DbSet<Venda> Venda { get; set; }
            public DbSet<VendaItem> VendaItens { get; set; }

            public MyDbContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "127.0.0.1";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "**********";
                var strCon = $"server={server};Port ={port};Database ={database};" +
                    $"Uid={username};Pwd={password}";
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            }
        }

        [TestMethod]
        public void TestInsertCidade()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade
                {
                    Nome = "Birigui",
                    Estado = "SP"
                };
                context.Cidade.Add(cidade);

                cidade = new Cidade
                {
                    Nome = "Aracatuba",
                    Estado = "SP"
                };
                context.Cidade.Add(cidade);

                context.SaveChanges();
            }
        }

        public void TestListCidade()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidade)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }

        }

        [TestMethod]
        public void TestInsertCliente()
        {
            using (var context = new MyDbContext())
            {
                var cidade = context.Cidade.FirstOrDefault(c => c.Id == 1);
                var cliente = new Cliente
                {
                    Nome = "Mariana",
                    Cidade = cidade,
                    Documento = "***.***.***-**",
                    Endereco = "Rua Pedro Cavalo, 709",
                    Bairro = "Portal da Pérola"
                };
                context.Cliente.Add(cliente);

                cidade = context.Cidade.FirstOrDefault(c => c.Id == 2);
                cliente = new Cliente
                {
                    Nome = "Angela",
                    Cidade = cidade,
                    Documento = "***.***.***-**",
                    Endereco = "Rua Islândia, 327",
                    Bairro = "Jardim São Paulo"
                };
                context.Cliente.Add(cliente);

                context.SaveChanges();
            }
        }

        public void TestListClientes()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Cliente)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }

        }

        [TestMethod]
        public void TestInsertGrupo()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo
                {
                    Nome = "Grupo 1"
                };
                context.Grupo.Add(grupo);

                grupo = new Grupo
                {
                    Nome = "Grupo2"
                };
                context.Grupo.Add(grupo);

                context.SaveChanges();
            }
        }

        public void TestInsertProduto()
        {
            using (var context = new MyDbContext())
            {
                //cria uma instância de grupo e adiciona ao contexto
                var grupo = new Grupo { Nome = "Eletrônicos" };
                context.Grupo.Add(grupo);
                context.SaveChanges();

                var produto = new Produto
                {
                    Nome = "Notebook",
                    Preco = 2500,
                    Quantidade = 10,
                    DataCompra = DateTime.Parse("2024-10-29"),
                    UnidadeVenda = "Varejo",
                    Grupo = grupo
                };

                context.Produto.Add(produto);
                context.SaveChanges();

                var savedProduct = context.Produto.FirstOrDefault(p => p.Nome == "Notebook" && p.Grupo.Id == grupo.Id);

                Assert.IsNotNull(savedProduct);
                Assert.AreEqual("Notebook", savedProduct.Nome);
                Assert.AreEqual(2500, savedProduct.Preco);
                Assert.AreEqual(1, savedProduct.Quantidade);
                Assert.AreEqual(DateTime.Parse("2024-10-29"), savedProduct.DataCompra);
                Assert.AreEqual("Varejo", savedProduct.UnidadeVenda);
                Assert.AreEqual(grupo.Id, savedProduct.Grupo.Id);
            }
        }

        public void TestListProduto()
        {
            using (var context = new MyDbContext())
            {
                foreach (var produto in context.Produto)
                {
                    Console.WriteLine(JsonSerializer.Serialize(produto));
                }

            }
        }

        public void TestInsertVenda()
        {
            using (var context = new MyDbContext())
            {
                //cria uma instância de grupo e adiciona ao contexto
                var grupo = new Grupo { Nome = "Eletrônicos" };
                context.Grupo.Add(grupo);
                context.SaveChanges();

                var produto1 = new Produto

                {
                    Nome = "Notebook",
                    Preco = 2500,
                    Quantidade = 10,
                    DataCompra = DateTime.Parse("2024-10-29"),
                    UnidadeVenda = "Varejo",
                    Grupo = grupo
                };

                var produto2 = new Produto
                {
                    Nome = "Mouse",
                    Preco = 1500,
                    Quantidade = 50,
                    DataCompra = DateTime.Parse("2024-10-29"),
                    UnidadeVenda = "Varejo",
                    Grupo = grupo
                };

                context.Produto.AddRange(produto1, produto2);
                context.SaveChanges();


            }
        }
    }
}
