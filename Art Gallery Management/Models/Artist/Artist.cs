﻿using Art_Gallery_Management.Models.ArtWorks;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Art_Gallery_Management.Models.Artists
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;

        // One-to-Many with ArtWork
        public ICollection<ArtWork> ArtWorks { get; } = new List<ArtWork>();


    }
}
