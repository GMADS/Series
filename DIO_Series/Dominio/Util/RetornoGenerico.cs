namespace DIO_Series.Dominio.Util
{
    public class RetornoGenerico
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Objeto { get; set; }

        public RetornoGenerico(string mensagem, bool sucesso, object objeto)
        {
            this.Mensagem = mensagem;
            this.Sucesso = sucesso;
            this.Objeto = objeto;
        }
    }
}