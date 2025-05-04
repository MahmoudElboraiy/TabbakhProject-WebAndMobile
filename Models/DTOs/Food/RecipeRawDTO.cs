﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Food
{
    public class RecipeRawDTO
    {
        public int RecipeId { get; set; }
        public string Recipe_Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Preparation_Method { get; set; }
        public int Time { get; set; }
        public string Type { get; set; } 
        public double Calories_100g { get; set; }
        public double Fat_100g { get; set; }
        public double Sugar_100g { get; set; }
        public double Protein_100g { get; set; }
        public double Carb_100 { get; set; }
        public string Ingredient_Name { get; set; } = null!;
    }
}
