using seed_desafio_cdc_api.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc_api.Validations
{
    public class EmailAlreadyExists : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = validationContext.GetService<AppDbContext>();

            if (context == null)
            {
                throw new InvalidOperationException("AppDbContext não está disponível no ValidationContext.");
            }

            var emailJaExiste = context.Autores.Any(u => u.Email == (string?)value);

            if (emailJaExiste)
            {
                return new ValidationResult(ErrorMessage ?? "Email já cadastrado.");
            }

            return ValidationResult.Success;
        }
    }
}
