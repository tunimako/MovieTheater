﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class ShowTime
    {
        [Key]
        public int Id { get; set; } //Galbūt galime saugoti kaip stringą sudarytą iš filmo pavadinimo ir skaičiaus indikuojančiu, kelintas tai yra šio filmo sensas;
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [ForeignKey("CinemaHall")]
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }
        [ForeignKey("Cinema")]
        public Guid? CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        public ICollection<ClientShowTime>? ClientShowTimes { get; set; }

        public ShowTime(DateTime start)
        {
            Start = start;
            End = start + Movie.Duration;
            ClientShowTimes = new List<ClientShowTime>();
        }
    }
}