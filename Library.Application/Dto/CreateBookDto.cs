using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    public class CreateBookDto
    {
        [Required(ErrorMessage ="Обязательное поле для заполнения.")]
        [StringLength(50, ErrorMessage ="Длина не более 50 символов.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения.")]
        [StringLength(50, ErrorMessage = "Длина не более 50 символов.")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения.")]
        [Range(1000, 2025, ErrorMessage ="Год выпуска вне диапазона.")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения.")]
        [StringLength(200, ErrorMessage = "Длина не более 200 символов.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения.")]
        [StringLength(50, ErrorMessage = "Длина не более 50 символов.")]
        public string ShelfName { get; set; }
    }
}
