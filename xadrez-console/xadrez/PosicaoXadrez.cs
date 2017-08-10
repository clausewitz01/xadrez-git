using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez (char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao() {
            //converte as casas do tabuleiro (0,0) => (8,A)
            return new Posicao(8 - linha, coluna - 'a');

        }
        public override string ToString() {
            //""=> forca a conversao para string
            return "" + coluna + linha;

        }

    }
}
