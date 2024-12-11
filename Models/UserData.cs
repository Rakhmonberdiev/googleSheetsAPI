using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace googleSheetsAPI.Models
{
    public class UserData
    {
        private const int MIN_NAME_LENGTH = 4;
        private const int MAX_NAME_LENGTH = 15;
        [Required]
        [StringLength(MAX_NAME_LENGTH, MinimumLength = MIN_NAME_LENGTH, ErrorMessage = "Длина имени должна быть от 4 до 15 символов.")]
        public string Name {  get; set; }
        [Required]
        [RegularExpression(@"^\+998\d{9}$", ErrorMessage = "Номер телефона должен начинаться с «+998», за которым следуют 9 цифр.")]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public DateTime CreatedD {  get; set; } = DateTime.UtcNow;
    }
}
