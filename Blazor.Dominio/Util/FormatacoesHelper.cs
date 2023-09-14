using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Blazor.Dominio.Util
{
    public static class FormatacoesHelper
    {
        public static string FormataCpfCnpj(string documento)
        {
            documento = documento.Replace(".", "").Replace("-", "").Replace("/", "");

            if (documento.Length == 11)
            {
                return documento.Substring(0, 3) + "." + documento.Substring(3, 3) + "." + documento.Substring(6, 3) + "-" + documento.Substring(9);
            }
            else if (documento.Length == 14)
            {
                return documento.Substring(0, 2) + "." + documento.Substring(2, 3) + "." + documento.Substring(5, 3) + "/" + documento.Substring(8, 4) + "-" + documento.Substring(12);
            }

            return documento;
        }


        public static DiaDaSemana NomeDia(DateTime data)
        {
            DayOfWeek nome = data.DayOfWeek;
            DiaDaSemana nomeDia = new DiaDaSemana();
            switch (nome)
            {
                case DayOfWeek.Monday:
                    nomeDia = DiaDaSemana.SegundaFeira;
                    break;
                case DayOfWeek.Tuesday:
                    nomeDia = DiaDaSemana.TercaFeira;
                    break;
                case DayOfWeek.Wednesday:
                    nomeDia = DiaDaSemana.QuartaFeira;
                    break;
                case DayOfWeek.Thursday:
                    nomeDia = DiaDaSemana.QuintaFeira;
                    break;
                case DayOfWeek.Friday:
                    nomeDia = DiaDaSemana.SextaFeira;
                    break;
                case DayOfWeek.Saturday:
                    nomeDia = DiaDaSemana.Sabado;
                    break;
                case DayOfWeek.Sunday:
                    nomeDia = DiaDaSemana.Domingo;
                    break;
            }

            return nomeDia;
        }


        public static DateTime AdicionaDiaSeForSabadoDomingo(DateTime dataInicial)
        {
            switch (dataInicial.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    {
                        dataInicial = dataInicial.AddDays(2);
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        dataInicial = dataInicial.AddDays(1);
                        break;
                    }
            }
            return dataInicial;
        }

        public static bool ValidaSeForSabadoDomingo(DateTime dataInicial)
        {
            bool retorno = false;
            switch (dataInicial.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    {
                        retorno = true;
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        retorno = true;
                        break;
                    }
            }
            return retorno;
        }


        public static string RetornaNomeDoMes(Int16 mes)
        {
            string nome = "";
            switch (mes)
            {
                case 1:
                    nome = "Janeiro";
                    break;
                case 2:
                    nome = "Fevereiro";
                    break;
                case 3:
                    nome = "Março";
                    break;
                case 4:
                    nome = "Abril";
                    break;
                case 5:
                    nome = "Maio";
                    break;
                case 6:
                    nome = "Junho";
                    break;
                case 7:
                    nome = "Julho";
                    break;
                case 8:
                    nome = "Agosto";
                    break;
                case 9:
                    nome = "Setembro";
                    break;
                case 10:
                    nome = "Outubro";
                    break;
                case 11:
                    nome = "Novembro";
                    break;
                case 12:
                    nome = "Dezembro";
                    break;
            }

            return nome;
        }


        public static string Cep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return cep;

            cep = SomenteNumeros2(cep);
            if (cep.Length < 8)
                cep = cep.PadRight(8, '0');

            return string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5));
        }


        public static string SomenteNumeros(string textoOriginal)
        {
            if (textoOriginal == null)
            {
                return "";
            }
            else
            {
                string texto = textoOriginal.Normalize(NormalizationForm.FormD);
                StringBuilder stringBuilder = new StringBuilder();

                for (int k = 0; k < texto.Length; k++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(texto[k]);
                    if (uc == UnicodeCategory.DecimalDigitNumber)
                        stringBuilder.Append(texto[k]);
                }
                return stringBuilder.ToString();
            }
        }



        public static string Limit(this string str, int tamanho)
        {
            if (str != null)
            {
                if (str.Length > tamanho)
                {
                    return str.Substring(0, tamanho);
                }
                return str;
            }
            return null;
        }


        public static string SomenteNumeros2(string textoOriginal)
        {
            if (!string.IsNullOrEmpty(textoOriginal))
            {
                return String.Concat(Regex.Split(textoOriginal, @"[^\d]"));
            }
            return string.Empty;
        }


        public static string Limita(string str, int inicio, int limite)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length <= inicio)
                {
                    return string.Empty;
                }
                else if (str.Length - inicio <= limite)
                {
                    return str.Substring(inicio);
                }
                else
                {
                    return str.Substring(inicio, limite);
                }
            }
            return string.Empty;
        }

        public static decimal Truncar(this decimal d, int casas)
        {
            double mult = Math.Pow(10, casas);
            double val = (double)d * mult;
            val = Math.Truncate(val);
            return new Decimal(val / mult);
        }

        public static decimal Truncar(this decimal? d, int casas)
        {
            if (d == null)
                return 0m;
            return d.Value.Truncar(casas);
        }

        public static decimal Arredondar(this decimal d, int casas)
        {
            return Math.Round(d, casas);
        }

        public static decimal Arredondar(this decimal? d, int casas)
        {
            if (d == null)
                return 0m;
            return d.Value.Arredondar(casas);
        }

        public static string MascaraValor(this decimal d)
        {
            return d.ToString("#,##0.00#;(#,##0.00#)");
        }

        public static string MascaraValor(this decimal? d)
        {
            if (d == null)
                return "0,00";
            return d.Value.MascaraValor();
        }

        public static string MascaraQuantidade(this decimal q)
        {
            return q.ToString("#,##0.000#;-#,##0.000#");
        }

        public static string MascaraQuantidade(this decimal? q)
        {
            if (q == null)
                return "0,000";
            return q.Value.MascaraValor();
        }

        public static string MascaraInteiro(this decimal d)
        {
            return Decimal.ToInt64(d).MascaraInteiro();
        }

        public static string MascaraInteiro(this decimal? d)
        {
            if (d == null)
                return "0";
            return d.Value.MascaraInteiro();
        }

        public static string MascaraInteiro(this int i)
        {
            long l = i;
            return l.MascaraInteiro();
        }

        public static string MascaraInteiro(this int? i)
        {
            if (i == null)
                return "0";
            return i.Value.MascaraInteiro();
        }

        public static string MascaraInteiro(this long l)
        {
            return l.ToString("#,##0;-#,##0");
        }

        public static string MascaraInteiro(this long? l)
        {
            if (l == null)
                return "0";
            return l.Value.MascaraInteiro();
        }

        public static decimal TruncarValor(decimal? valor, int casas)
        {
            if (valor != null)
            {
                string str_valor_inteiro, str_valor, valor_string;
                int aux, casas_valor;
                Int64 valor_inteiro = Convert.ToInt64(Math.Truncate((decimal)valor));
                str_valor_inteiro = valor_inteiro.ToString();
                str_valor = valor.ToString();
                casas_valor = str_valor.Length - str_valor_inteiro.Length - 1;
                casas = (casas_valor < casas) ? casas_valor : casas;
                aux = str_valor_inteiro.Length + 1 + casas;
                valor_string = valor.ToString().Substring(0, aux);
                return Convert.ToDecimal(valor_string);
            }

            return 0.00M;
        }

        public static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Valida CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ</param>
        /// <returns>CNPJ válido = true | CNPJ inválido = false</returns>
        public static bool ValidaCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool ValidarDocumento(string documento)
        {
            if (documento == null)
                return false;

            documento = documento.Trim();
            documento = documento.Replace(".", "").Replace("-", "").Replace("/", "");

            switch (documento.Length)
            {
                case 11:
                    return ValidarCpf(documento);
                case 14:
                    return ValidaCNPJ(documento);
            }
            return false;
        }

        /// <summary>
        /// Verifica se a proprieade de navegação é válida
        /// </summary>
        /// <param name="T">Entidade</param>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        public static void ParaObjetoValido(object T, string nomePropriedade)
        {
            if (T == null)
                throw new InvalidOperationException(nomePropriedade + " é obrigatório!");
        }

        /// <summary>
        /// Verifica se ID de uma proprieade é válido
        /// </summary>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        /// <param name="id">ID</param>
        public static void IdValido(string nomePropriedade, long id)
        {
            ParaIdValido(id, nomePropriedade + " id inválido!");
        }

        /// <summary>
        /// Verifica se ID é válido
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="mensagemErro">Mensagem de erro.</param>
        public static void ParaIdValido(long id, string mensagemErro)
        {
            if (id <= 0)
                throw new InvalidOperationException(mensagemErro);
        }

        /// <summary>
        /// Verifica se número é negativo
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        public static void ParaNegativo(long numero, string nomePropriedade)
        {
            if (numero < 0)
                throw new InvalidOperationException(nomePropriedade + " não pode ser negativo!");
        }

        /// <summary>
        /// Verifica se string de uma propriedade é nula ou vazia e exibe mensagem padrão
        /// </summary>
        /// <param name="value">String</param>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        public static void ParaNuloOuVazioMensagmPadrao(string value, string nomePropriedade)
        {
            if (String.IsNullOrEmpty(value))
                throw new InvalidOperationException(nomePropriedade + " é obrigatório!");
        }

        /// <summary>
        /// Verifica se string de uma propriedade é nula ou vazia e exibe mensagem customizada
        /// </summary>
        /// <param name="value">String</param>
        /// <param name="errorMessage">Mensagem personalizada</param>
        public static void ParaNuloOuVazio(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new InvalidOperationException(errorMessage);
        }

        /// <summary>
        /// Verifica tamanho de uma string de uma propriedade
        /// </summary>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        /// <param name="texto">String</param>
        /// <param name="tamanhoMaximo">Tamanho mámixo</param>
        public static void TamanhoTexto(string nomePropriedade, string texto, int tamanhoMaximo)
        {
            TamanhoTexto(texto, tamanhoMaximo, nomePropriedade + " não pode ter mais que " + tamanhoMaximo + " caracteres");
        }

        /// <summary>
        /// Verifica tamanho de uma string e exibe mensagem personalizada
        /// </summary>
        /// <param name="texto">String</param>
        /// <param name="tamanhoMaximo">Tamanho máximo</param>
        /// <param name="mensagem">Mensagem customizada</param>
        public static void TamanhoTexto(string texto, int tamanhoMaximo, string mensagem)
        {
            var length = texto.Length;
            if (length > tamanhoMaximo)
            {
                throw new InvalidOperationException(mensagem);
            }
        }

        /// <summary>
        /// Verifica tamanho mínimo e máximo de uma string de uma propriedade
        /// </summary>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        /// <param name="texto">String</param>
        /// <param name="minimo">Tamanho mínimo</param>
        /// <param name="maximo">Tamanho máximo</param>
        public static void TamanhoTexto(string nomePropriedade, string texto, int minimo, int maximo)
        {
            TamanhoTexto(texto, minimo, maximo, nomePropriedade + " deve ter de " + minimo + " à " + maximo + " caracteres!");
        }

        /// <summary>
        /// Verifica tamanho mínimo e máximo de uma string e exibe mensagem personalizada
        /// </summary>
        /// <param name="texto">String</param>
        /// <param name="minimo">Tamanho mínimo</param>
        /// <param name="maximo">Tamanho máximo</param>
        /// <param name="mensagem">Mensagem personalizada</param>
        public static void TamanhoTexto(string texto, int minimo, int maximo, string mensagem)
        {
            if (String.IsNullOrEmpty(texto))
                texto = String.Empty;

            var length = texto.Length;
            if (length < minimo || length > maximo)
            {
                throw new InvalidOperationException(mensagem);
            }
        }

        /// <summary>
        /// Compara duas string e exibe mensagem personalizada
        /// </summary>
        /// <param name="a">String A</param>
        /// <param name="b">String B</param>
        /// <param name="mesangemErro">Mensagem personalizada</param>
        public static void SaoIguais(string a, string b, string mesangemErro)
        {
            if (a != b)
                throw new InvalidOperationException(mesangemErro);
        }

        public static void DataValida(string nomePropriedade, DateTime data, string mensagemErro)
        {
            if (data == DateTime.MinValue)
                throw new InvalidOperationException(nomePropriedade + " " + mensagemErro);
        }

        public static void DataValida(string nomePropriedade, DateTime data)
        {
            DataValida(nomePropriedade, data, "Data informada não é válida.");
        }

        /// <summary>
        /// Retorna se a base do CNPJ é a mesma entre os 2 CNPJs.
        /// </summary>
        /// <param name="cnpj1"></param>
        /// <param name="cnpj2"></param>
        public static bool TemMesmaBaseCNPJ(string cnpj1, string cnpj2)
        {
            cnpj1 =  SomenteNumeros(cnpj1);
            cnpj2 =  SomenteNumeros(cnpj2);
            return  Limita(cnpj1, 0, 8).Equals( Limita(cnpj2, 0, 8));
        }

        public static string ValidaNome(string nome)
        {
            const string remover = @"\\";
            const string caracterBranco = "";
            Regex rgx = new Regex(remover);
            return rgx.Replace(nome, caracterBranco);
        }

    }
       
}
