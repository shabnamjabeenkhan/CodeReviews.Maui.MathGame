﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJKMathGameMuai.Models
{
    [Table ("game")]
   public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public  int Id { get; set; }
        public GameOperation Type { get; set; }

        public int Score { get; set; }  
        public DateTime DatePlayed { get; set; }    
    }

     public enum GameOperation
    {
        Additon,
        Subtraction, 
        Multiplication,
        Division,
    }
}
