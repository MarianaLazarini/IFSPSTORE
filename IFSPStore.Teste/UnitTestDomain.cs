using IFSPStory.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace IFSPStory.Test
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void TestCidade()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");

            Debug.WriteLine(JsonSerializer.Serialize(cidade));

            Assert.AreEqual(cidade.Nome, "Birigui");
            Assert.AreEqual(cidade.Estado, "SP");
        }

        [TestMethod]
        public void TestCliente()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");
            Cliente cliente = new Cliente(1, "Angela", "Rua Islândia 327", "Jardim", "123", cidade);

            Debug.WriteLine(JsonSerializer.Serialize(cliente));

            Assert.AreEqual(cliente.Nome, "Angela");
            Assert.AreEqual(cliente.Endereco, "Rua Islândia 327");
            Assert.AreEqual(cliente.Bairro, "Jardim");
            Assert.AreEqual(cliente.Documento, "123");
            Assert.AreEqual(cliente.Cidade.Nome, "Birigui"); 
        }

        [TestMethod]
        public void TestUsuario()
        {
            DateTime dataCadastro = new DateTime(2024, 10, 28);
            DateTime dataLogin = new DateTime(2024, 10, 27);//ano,mês, dia
            Usuario usuario = new Usuario(1, "Mariana", "456", "marisolazarini", "m.lazarini@aluno.ifsp.edu.br", dataCadastro, dataLogin, true); //true = Ativo caso seja Inativo seria false

            Assert.AreEqual(usuario.Nome, "Mariana");
            Assert.AreEqual(usuario.Senha, "456");
            Assert.AreEqual(usuario.Login, "marisolazarini");
            Assert.AreEqual(usuario.Email, "m.lazarini@aluno.ifsp.edu.br");
            Assert.AreEqual(usuario.Ativo, true);
        }

        [TestMethod]
        public void TestVenda()
        {
            DateTime data = new DateTime(2024, 10, 28);

            DateTime dataCadastro = new DateTime(2024, 10, 28);
            DateTime dataLogin = new DateTime(2024, 10, 27);//ano,mês, dia
            Usuario usuario = new Usuario(1, "Mariana", "456", "marisolazarini", "m.lazarini@aluno.ifsp.edu.br", dataCadastro, dataLogin, true); //true = Ativo caso seja Inativo seria false

            Cidade cidade = new Cidade(1, "Birigui", "SP");
            Cliente cliente = new Cliente(1, "Angela", "Rua Islândia 327", "123", "Jardim", cidade);

            Grupo grupo = new Grupo(1, "Varejo");
            Produto produto = new Produto(1, "Notebook", 5000.00f, 2, new DateTime(2024, 1, 1), "5", grupo);

            var vendaItem = new List<VendaItem>();
            vendaItem.Add(new VendaItem(1, produto, 1, 15, 15, null));
            Venda venda = new Venda(1, data, 1500, usuario, cliente, vendaItem);

            //Assert.AreEqual(venda.Data, (2024, 10, 28));
            Assert.AreEqual(venda.ValorTotal, 1500);

        }

        [TestMethod]
        public void TestGrupo()
        {
            Grupo grupo = new Grupo(1, "Varejo");

            Assert.AreEqual(grupo.Nome, "Varejo");
        }

        [TestMethod]
        public void TestProduto()
        {
            DateTime dataCompra = new DateTime(2024, 10, 28);

            Grupo grupo = new Grupo(1, "Varejo");

            Produto produto = new Produto(1, "Notebook", (float)5000.000, 2, dataCompra, "5", grupo);

            Assert.AreEqual(produto.Nome, "Notebook");
            Assert.AreEqual(produto.Preco, (float)5000.00);
            // Assert.AreEqual(produto.DataCompra, (2024, 10, 28));
            Assert.AreEqual(produto.UnidadeVenda, "5");
            Assert.AreEqual(produto.Grupo.Id, 1);
        }
    }
}