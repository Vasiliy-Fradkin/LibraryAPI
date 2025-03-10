﻿namespace Library.Application.DTO
{
    public class GetBookByIdDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ShelfName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
