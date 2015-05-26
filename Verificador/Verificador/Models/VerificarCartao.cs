using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Verificador.Models
{
    
    public class VerificarCartao
    {
        private string _numero;
        private string _bandeira;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string Bandeira
        {
            get { return _bandeira; }
        }

        public VerificarCartao(string numero)
        {
            _numero = numero;
        }

        public bool Validar()
        {
            this._bandeira = GetBandeira();


            char[] invertido = this._numero.Trim().ToCharArray();
            Array.Reverse(invertido);

            int sum1 = 0;
            int sum2 = 0;
            int total = 0;

            for (int i = 1; i < invertido.Length; i+=2)
            {
                int alg = (int)Char.GetNumericValue(invertido[i]);
                alg = alg * 2;

                if (alg >= 10)
                {
                    char[] temp = alg.ToString().ToCharArray();
                    alg = (int)Char.GetNumericValue(temp[0]) + (int)Char.GetNumericValue(temp[1]);
                }

                sum1 += alg;
            }

            for (int i = 0; i < invertido.Length; i+=2)
            {
                sum2 += (int)Char.GetNumericValue(invertido[i]);
            }

            total = sum1 + sum2;

            if(total % 10 == 0)
                return true;

            return false;
        }

        private string GetBandeira()
        {
            if (this._numero.StartsWith("4"))
               return "VISA";

            if (this._numero.StartsWith("6011"))
                return "DISCOVER";

            if (this._numero.StartsWith("34") || this._numero.StartsWith("37"))
                return "AMEX";

            if (this._numero.StartsWith("51") || this._numero.StartsWith("52") || this._numero.StartsWith("53") || this._numero.StartsWith("54"))
                return "MASTERCARD";

            return "DESCONHECIDO";
        }
    }
}