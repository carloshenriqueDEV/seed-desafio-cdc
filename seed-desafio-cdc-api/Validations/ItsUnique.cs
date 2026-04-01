using seed_desafio_cdc_api.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc_api.Validations
{
    public class ItsUniqueAttribute : ValidationAttribute
    {
        public string? EntityName { get; set; }
        public string? PropertyName { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var dbContext = (AppDbContext?)validationContext.GetService(typeof(AppDbContext));

            if (dbContext == null)
            {
                throw new InvalidOperationException("Não foi possível carregar o AppDbContext.");
            }            
           
            if (!dbContext.EUnico(EntityName, PropertyName, value))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
