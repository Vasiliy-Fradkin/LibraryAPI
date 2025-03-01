using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dto
{
    public class UpdateBookDto
    {
        [StringLength(50, ErrorMessage = "Длина не более 50 символов.")]
        public string? Title { get; set; }


        [StringLength(50, ErrorMessage = "Длина не более 50 символов.")]
        public string? Author { get; set; }


        [Range(1000, 2025, ErrorMessage ="Некорректный введён год.")]
        public int? Year { get; set; }


        [StringLength(250, ErrorMessage = "Длина не более 50 символов.")]
        public string? Description { get; set; }


        [StringLength(50, ErrorMessage = "Длина не более 50 символов.")]
        public string? ShelfName { get; set; }   
    }
}