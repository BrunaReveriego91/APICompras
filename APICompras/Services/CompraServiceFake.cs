using APICompras.Models;
using APICompras.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIComprasTest
{
    public class CompraServiceFake : ICompraService
    {
        /*  Atributo [Fact] => Utilizado pelo xUnit para marcar os métodos de testes. Além dos métodos de testes, também
         *  podemos ter vários métodos auxiliares na classe de teste .
            Atributo [Fact] ou [Theory] => [Fact] é utilizado para testes sem parâmetros e [Theory] para testes como parâmetros.
            Testes unitários é utilizado o princípio AAA : Act,Arrange e Assert (Organizar, Agir e Assertir).
            
            Arrange => Aonde se prepara tudo para o teste, prepara a cena para testar (criar os objetos e configurá-los conforme necessário)
            Act => É onde o método que está sendo testado é executado;
            Assert => Parte final do teste em que se compara o que se espera que aconteça e o resultado real da execução do método de teste.
         
         */



        private readonly List<CompraItem> _compra;

        public CompraServiceFake()
        {
            _compra = new List<CompraItem>()
            {
                new CompraItem() { Id = 1, Nome = "Tablet SamSung 7",
                                   Fabricante ="SamSung", Preco = 765.00M },
                new CompraItem() { Id = 2, Nome = "IPad 7",
                                   Fabricante ="Apple", Preco = 644.00M },
                new CompraItem() { Id = 3, Nome = "Notebook Lenovo 13",
                                   Fabricante ="Lenovo", Preco = 987.00M },
                new CompraItem() { Id = 4, Nome = "Monitor LG 23",
                                   Fabricante ="LG", Preco = 879.00M },
                new CompraItem() { Id = 5, Nome = "HD SSD Asus 1T",
                                   Fabricante ="Assus", Preco = 612.00M }
            };
        }


        public CompraItem Add(CompraItem novoItem)
        {
            novoItem.Id = GeraId();
            _compra.Add(novoItem);
            return novoItem;
        }

        private int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        public IEnumerable<CompraItem> GetAllItems()
        {
            return _compra;
        }

        public CompraItem GetById(int id)
        {
            return _compra.Where(a => a.Id == id)
               .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var item = _compra.First(a => a.Id == id);
            _compra.Remove(item);
        }
    }
}
