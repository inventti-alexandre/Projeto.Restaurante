namespace Projeto.Restaurante.MVC.Models
{
    public class Alerta
    {
        #region Propriedades
        public string Mensagem { get; private set; }
        public TipoDeAlerta TipoDeAlerta { get; private set; }
        #endregion

        #region Construtores
        public Alerta(string mensagem, TipoDeAlerta tipoDeAlerta)
        {
            Mensagem = mensagem;
            TipoDeAlerta = tipoDeAlerta;
        }
        #endregion
    }
}