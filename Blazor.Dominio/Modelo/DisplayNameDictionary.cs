using System.Text;

namespace Blazor.Dominio.Modelo
{
    public static class DisplayNameDictionary
    {
       
        private static readonly Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "Codigo", "Código" },
            { "Descricao", "Descrição" },
            { "Situacao", "Situação" },
            { "Mes", "Mês" },
            { "Eh", "É" }
        };


        public static string Get(string name)
        {
            if (!dictionary.ContainsKey(name))
            {
                return name;
            }

            return dictionary[name];
        }

        //public static void Put(string name, string correctName)
        //{
        //    dictionary[name] = correctName;
        //}


        public static string CorrectMemberName(string memberName)
        {
            string text = memberName.SplitPascalCase();
            if (text.Contains(" "))
            {
                string[] array = text.Split(' ');
                StringBuilder sb = new StringBuilder();
                array.Each(delegate (string w)
                {
                    sb.Append(Get(w)).Append(" ");
                });
                return sb.ToString().TrimEnd();
            }

            return Get(memberName);
        }
        public static string SplitPascalCase(this string name)
        {
            return name.SplitUpperCase(' ', lower: false);
        }

        public static string SplitUpperCase(this string name, char separetor, bool lower)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            StringBuilder stringBuilder = new StringBuilder(name.Length + 5);
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (char.IsUpper(c) && i > 1 && (!char.IsUpper(name[i - 1]) || (i + 1 < name.Length && !char.IsUpper(name[i + 1]))))
                {
                    stringBuilder.Append(separetor);
                }

                if (lower)
                {
                    c = char.ToLowerInvariant(c);
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}
