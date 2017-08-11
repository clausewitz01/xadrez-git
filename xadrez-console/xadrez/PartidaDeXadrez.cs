using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno   {get;private set;}
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
            terminada = false;
        }
        public void executarMovimento(Posicao origem,Posicao destino) {

            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }
        public void realizaJogada(Posicao origem, Posicao destino) {
            executarMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Nao ha pecas na posicao ecolhida.");
            }
            else if (jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peca nao eh a sua");
            }
            else if (!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Nao existe movimentos possiveis com essa peca");
            }
        }     
        public void validarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posicao de destino invalida");
            }
        }
        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;            }
        }
        private void colocarPecas() {
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('g', 5).toPosicao());
        }
    }
}
