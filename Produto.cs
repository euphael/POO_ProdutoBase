using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_POO {
    public class Produto {

        #region atributos
        private string desc;
        private double precoCusto;
        private double margemLucro;

        #endregion

        #region construtores
        public Produto(string desc, double precoCusto, double margemLucro) {
            this.desc = desc;
            this.precoCusto = precoCusto;
            this.margemLucro = margemLucro;
        }
        #endregion

        #region métodos de negócio
        public double ValorVenda() {
            double valorCustoMargem = (precoCusto / 100) * margemLucro;
            double valorTotal = precoCusto + valorCustoMargem;
            return valorTotal;
        }

        public string NotaDeVenda() {
            double valorTotal = ValorVenda();
            return " Produto - " + desc + " Valor - " + "R$" + valorTotal;
        }
        #endregion
    }
}
