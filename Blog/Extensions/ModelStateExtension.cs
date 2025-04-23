using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        public static List<String> GetErrors(this ModelStateDictionary modelState)
        //o método retorna uma lista de mensagens de erro
        //(this ModelStateDictionary modelState) transforma o método em uma extensão do ModelStateDictionary permitindo fazer o "ModelState.GetErrors();"
        {
            var result = new List<string>(); //Cria uma lista vazia chamada result, que vai armazenar os erros encontrados.
            foreach (var item in modelState.Values) // Percorre cada valor do ModelState. Cada valor representa o estado de um campo, como Title e Slug
            {
                foreach (var error in item.Errors) // Para cada campo (item), percorre os erros que ele contém.
                {
                    result.Add(error.ErrorMessage); // Adiciona a mensagem de erro à lista result.
                }
            }
            return result;
        }
    }
}
