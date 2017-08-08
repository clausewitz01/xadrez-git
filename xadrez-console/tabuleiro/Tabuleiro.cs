using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro {
    class Tabuleiro {

        public int linhas { get; set; }
        public int colunass { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {

            this.linhas = linhas;
            this.colunass = colunas;
            pecas = new Peca[linhas, colunas];


        }
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }
        public void colocarPeca(Peca p, Posicao pos) {
            //posicao eh um atributo da classe peca
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;

        }
    }
}